using System;
using Volo.Abp.Application.Dtos;

namespace EasyAbp.CacheManagement.CacheItems.Dtos
{
    public class CacheItemDto : EntityDto<Guid>
    {
        public string CacheName { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }
        
        public bool IgnoreMultiTenancy { get; set; }

        public bool TenantAllowed { get; set; }
    }
}