using System;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.CacheManagement.CacheItems
{
    [RemoteService(Name = "EasyAbpCacheManagement")]
    [Route("/api/cacheManagement/cacheItem")]
    public class CacheItemController : CacheManagementController, ICacheItemAppService
    {
        private readonly ICacheItemAppService _service;

        public CacheItemController(ICacheItemAppService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<CacheItemDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }

        [HttpGet]
        public Task<PagedResultDto<CacheItemDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            return _service.GetListAsync(input);
        }

        [HttpPost]
        public Task<CacheItemDto> CreateAsync(CreateUpdateCacheItemDto input)
        {
            return _service.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public Task<CacheItemDto> UpdateAsync(Guid id, CreateUpdateCacheItemDto input)
        {
            return _service.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            return _service.DeleteAsync(id);
        }

        [HttpGet]
        [Route("keys/{cacheItemId}")]
        public Task<ListResultDto<CacheItemDataDto>> GetKeysAsync(Guid cacheItemId)
        {
            return _service.GetKeysAsync(cacheItemId);
        }

        [HttpGet]
        [Route("data/{cacheItemId}")]
        public Task<CacheItemDataDto> GetDataAsync(Guid cacheItemId, string cacheKey)
        {
            return _service.GetDataAsync(cacheItemId, cacheKey);
        }

        [HttpPost]
        [Route("clearSpecific")]
        public Task ClearSpecificAsync(ClearSpecificCacheItemDto input)
        {
            return _service.ClearSpecificAsync(input);
        }

        [HttpPost]
        [Route("clear")]
        public Task ClearAsync(ClearCacheItemDto input)
        {
            return _service.ClearAsync(input);
        }

        [HttpPost]
        [Route("clearAll")]
        public Task ClearAllAsync()
        {
            return _service.ClearAllAsync();
        }
    }
}