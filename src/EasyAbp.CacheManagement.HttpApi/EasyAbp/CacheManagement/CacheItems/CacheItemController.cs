using System;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.CacheManagement.CacheItems
{
    [RemoteService(Name = "EasyAbpCacheManagement")]
    [Route("/api/cache-management/cache-item")]
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
        [Route("keys/{id}")]
        public Task<ListResultDto<CacheItemDataDto>> GetKeysAsync(Guid id)
        {
            return _service.GetKeysAsync(id);
        }

        [HttpGet]
        [Route("data/{id}/{cacheKey}")]
        public Task<CacheItemDataDto> GetDataAsync(Guid id, string cacheKey)
        {
            return _service.GetDataAsync(id, cacheKey);
        }

        [HttpPost]
        [Route("clear/{id}/{cacheKey}")]
        public Task ClearByKeyAsync(Guid id, string cacheKey)
        {
            return _service.ClearByKeyAsync(id, cacheKey);
        }

        [HttpPost]
        [Route("clear/{id}")]
        public Task ClearAsync(Guid id)
        {
            return _service.ClearAsync(id);
        }

        [HttpPost]
        [Route("clear/all")]
        public Task ClearAllAsync()
        {
            return _service.ClearAllAsync();
        }
    }
}