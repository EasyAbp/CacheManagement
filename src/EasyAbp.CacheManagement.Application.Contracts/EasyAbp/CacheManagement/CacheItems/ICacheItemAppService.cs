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
        Task<ListResultDto<CacheItemDataDto>> GetKeysAsync(Guid cacheItemId);

        Task<CacheItemDataDto> GetDataAsync(Guid cacheItemId, string cacheKey);
        
        Task ClearSpecificAsync(ClearSpecificCacheItemDto input);
        
        Task ClearAsync(ClearCacheItemDto input);
        
        Task ClearAllAsync();
    }
}