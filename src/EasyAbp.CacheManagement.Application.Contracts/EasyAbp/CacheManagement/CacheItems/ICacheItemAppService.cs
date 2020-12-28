using System;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace EasyAbp.CacheManagement.CacheItems
{
    public interface ICacheItemAppService :
        ICrudAppService< 
            CacheItemDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateUpdateCacheItemDto,
            CreateUpdateCacheItemDto>
    {
        Task<ListResultDto<CacheItemDataDto>> GetKeysAsync(Guid id);

        Task<CacheItemDataDto> GetDataAsync(Guid id, string cacheKey);
        
        Task ClearByKeyAsync(Guid id, string cacheKey);
        
        Task ClearAsync(Guid id);
        
        Task ClearAllAsync();
    }
}