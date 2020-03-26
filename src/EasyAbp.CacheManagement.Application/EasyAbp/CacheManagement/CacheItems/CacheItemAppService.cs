using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.Authorization;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

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
        private readonly ICacheItemRepository _repository;

        public CacheItemAppService(
            ICacheItemManager cacheItemManager,
            ICacheItemRepository repository) : base(repository)
        {
            _cacheItemManager = cacheItemManager;
            _repository = repository;
        }

        [Authorize(CacheManagementPermissions.CacheItems.Default)]
        public async Task<ListResultDto<CacheItemDataDto>> GetKeysAsync(Guid cacheItemId)
        {
            var cacheItem = await _repository.GetAsync(cacheItemId);

            var keys = await _cacheItemManager.GetKeysAsync(cacheItem);

            return new ListResultDto<CacheItemDataDto>(
                new List<CacheItemDataDto>(keys.Select(key => new CacheItemDataDto
                    {CacheItemId = cacheItemId, CacheKey = key})));
        }

        [Authorize(CacheManagementPermissions.CacheItems.Default)]
        public async Task<CacheItemDataDto> GetDataAsync(Guid cacheItemId, string cacheKey)
        {
            var cacheItem = await _repository.GetAsync(cacheItemId);

            var keys = await _cacheItemManager.GetKeysAsync(cacheItem);

            var key = keys.Single(key => key.Equals(cacheKey));

            return new CacheItemDataDto
            {
                CacheItemId = cacheItemId,
                CacheKey = cacheKey,
                CacheValue = await _cacheItemManager.GetValueAsync(key)
            };
        }

        [Authorize(CacheManagementPermissions.CacheItems.ClearCache)]
        public async Task ClearSpecificAsync(ClearSpecificCacheItemDto input)
        {
            var cacheItem = await _repository.GetAsync(input.CacheItemId);

            await AuthorizationService.CheckAsync(cacheItem, CacheManagementPermissions.CacheItems.ClearCache);
            
            await _cacheItemManager.ClearSpecificAsync(cacheItem, input.CacheKey);
        }

        [Authorize(CacheManagementPermissions.CacheItems.ClearCache)]
        public async Task ClearAsync(ClearCacheItemDto input)
        {
            var cacheItem = await _repository.GetAsync(input.CacheItemId);

            await AuthorizationService.CheckAsync(cacheItem, CacheManagementPermissions.CacheItems.ClearCache);

            await _cacheItemManager.ClearAsync(cacheItem);
        }

        [Authorize(CacheManagementPermissions.CacheItems.ClearAllCache)]
        public async Task ClearAllAsync()
        {
            await _cacheItemManager.ClearAllAsync();
        }
    }
}