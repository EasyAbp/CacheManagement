using EasyAbp.CacheManagement.CacheItems;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.CacheManagement;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CacheItemToCacheItemDtoMapper : MapperBase<CacheItem, CacheItemDto>
{
    public override partial CacheItemDto Map(CacheItem source);

    public override partial void Map(CacheItem source, CacheItemDto destination);
}
