using EasyAbp.CacheManagement.CacheItems.Dtos;
using EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem.ViewModels;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace EasyAbp.CacheManagement.Web;

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CacheItemDtoToCreateEditCacheItemViewModelMapper : MapperBase<CacheItemDto, CreateEditCacheItemViewModel>
{
    public override partial CreateEditCacheItemViewModel Map(CacheItemDto source);

    public override partial void Map(CacheItemDto source, CreateEditCacheItemViewModel destination);
}

[Mapper(RequiredMappingStrategy = RequiredMappingStrategy.Target)]
public partial class CreateEditCacheItemViewModelToCreateUpdateCacheItemDtoMapper : MapperBase<CreateEditCacheItemViewModel, CreateUpdateCacheItemDto>
{
    public override partial CreateUpdateCacheItemDto Map(CreateEditCacheItemViewModel source);

    public override partial void Map(CreateEditCacheItemViewModel source, CreateUpdateCacheItemDto destination);
}
