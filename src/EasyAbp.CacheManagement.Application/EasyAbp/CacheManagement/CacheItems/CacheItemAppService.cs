using System;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.Authorization;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Caching;
using Volo.Abp.MultiTenancy;

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

        [Authorize(CacheManagementPermissions.CacheItems.ClearCache)]
        public async Task<ClearCacheItemResultDto> ClearAsync(ClearCacheItemDto input)
        {
            var cacheItem = await _repository.GetAsync(input.CacheItemId);

            await AuthorizationService.CheckAsync(cacheItem, CacheManagementPermissions.CacheItems.ClearCache);
            
            await _cacheItemManager.ClearAsync(cacheItem, input.CacheKey);
            
            return new ClearCacheItemResultDto
            {
                CacheItemId = cacheItem.Id,
                Count = 1
            };
        }

        public async Task<ClearCacheItemResultDto> ClearAllAsync(ClearAllCacheItemDto input)
        {
            throw new NotImplementedException();
        }
    }
}