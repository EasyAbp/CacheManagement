using EasyAbp.CacheManagement.CacheItems;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using AutoMapper;

namespace EasyAbp.CacheManagement
{
    public class CacheManagementApplicationAutoMapperProfile : Profile
    {
        public CacheManagementApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<CacheItem, CacheItemDto>();
            CreateMap<CreateUpdateCacheItemDto, CacheItem>(MemberList.Source);
        }
    }
}
