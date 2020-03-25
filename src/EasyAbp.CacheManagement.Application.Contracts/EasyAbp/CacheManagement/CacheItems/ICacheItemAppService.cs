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
        Task<ClearCacheItemResultDto> ClearAsync(ClearCacheItemDto input);
        
        Task<ClearCacheItemResultDto> ClearAllAsync(ClearAllCacheItemDto input);
    }
}