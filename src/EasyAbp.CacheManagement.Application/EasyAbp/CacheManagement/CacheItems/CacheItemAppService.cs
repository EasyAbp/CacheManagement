using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.Authorization;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.CacheManagement.CacheItems
{
    public class CacheItemAppService : CrudAppService<CacheItem, CacheItemDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateCacheItemDto, CreateUpdateCacheItemDto>,
        ICacheItemAppService
    {
        protected override string CreatePolicyName { get; set; } = CacheManagementPermissions.CacheItems.Create;
        protected override string DeletePolicyName { get; set; } = CacheManagementPermissions.CacheItems.Delete;
        protected override string UpdatePolicyName { get; set; } = CacheManagementPermissions.CacheItems.Update;
        protected override string GetPolicyName { get; set; } = CacheManagementPermissions.CacheItems.Default;
        protected override string GetListPolicyName { get; set; } = CacheManagementPermissions.CacheItems.Default;

        private readonly ICacheItemManager _cacheItemManager;

        public CacheItemAppService(
            ICacheItemManager cacheItemManager,
            ICacheItemRepository repository) : base(repository)
        {
            _cacheItemManager = cacheItemManager;
        }

        protected override async Task<CacheItem> GetEntityByIdAsync(Guid id)
        {
            var cacheItem = await base.GetEntityByIdAsync(id);

            if (CurrentTenant.Id.HasValue && !cacheItem.TenantAllowed)
            {
                throw new EntityNotFoundException(typeof(CacheItem), id);
            }

            return cacheItem;
        }

        protected override async Task<IQueryable<CacheItem>> CreateFilteredQueryAsync(PagedAndSortedResultRequestDto input)
        {
            return CurrentTenant.Id.HasValue
                ? (await base.CreateFilteredQueryAsync(input)).Where(i => i.TenantAllowed)
                : await base.CreateFilteredQueryAsync(input);
        }

        [Authorize(CacheManagementPermissions.CacheItems.Default)]
        public virtual async Task<ListResultDto<CacheItemDataDto>> GetKeysAsync(Guid id)
        {
            var cacheItem = await GetEntityByIdAsync(id);

            var keys = await _cacheItemManager.GetKeysAsync(cacheItem);

            return new ListResultDto<CacheItemDataDto>(
                new List<CacheItemDataDto>(keys.Select(key => new CacheItemDataDto
                    {Id = id, CacheKey = key})));
        }

        [Authorize(CacheManagementPermissions.CacheItems.Default)]
        public virtual async Task<CacheItemDataDto> GetDataAsync(Guid id, string cacheKey)
        {
            var cacheItem = await GetEntityByIdAsync(id);

            var keys = await _cacheItemManager.GetKeysAsync(cacheItem);

            var key = keys.Single(x => x.Equals(cacheKey));

            return new CacheItemDataDto
            {
                Id = id,
                CacheKey = cacheKey,
                CacheValue = await _cacheItemManager.GetValueAsync(key)
            };
        }

        [Authorize(CacheManagementPermissions.CacheItems.ClearCache)]
        public virtual async Task ClearByKeyAsync(Guid id, string cacheKey)
        {
            var cacheItem = await GetEntityByIdAsync(id);

            await AuthorizationService.CheckAsync(cacheItem, CacheManagementPermissions.CacheItems.ClearCache);
            
            await _cacheItemManager.ClearSpecificAsync(cacheItem, cacheKey);
        }

        [Authorize(CacheManagementPermissions.CacheItems.ClearCache)]
        public virtual async Task ClearAsync(Guid id)
        {
            var cacheItem = await GetEntityByIdAsync(id);

            await AuthorizationService.CheckAsync(cacheItem, CacheManagementPermissions.CacheItems.ClearCache);

            await _cacheItemManager.ClearAsync(cacheItem);
        }

        [Authorize(CacheManagementPermissions.CacheItems.ClearAllCache)]
        public virtual async Task ClearAllAsync()
        {
            await _cacheItemManager.ClearAllAsync();
        }
    }
}