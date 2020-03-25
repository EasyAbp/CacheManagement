using EasyAbp.CacheManagement.CacheItems.Dtos;
using AutoMapper;
using EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem.ViewModels;

namespace EasyAbp.CacheManagement.Web
{
    public class CacheManagementWebAutoMapperProfile : Profile
    {
        public CacheManagementWebAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CacheItemDto, CreateEditCacheItemViewModel>();
            CreateMap<CreateEditCacheItemViewModel, CreateUpdateCacheItemDto>();
        }
    }
}
