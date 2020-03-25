using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.CacheManagement.CacheItems.Dtos
{
    public class CreateUpdateCacheItemDto
    {
        [Required]
        [DisplayName("CacheItemFullTypeName")]
        public string FullTypeName { get; set; }

        [Required]
        [DisplayName("CacheItemDisplayName")]
        public string DisplayName { get; set; }

        [DisplayName("CacheItemDescription")]
        public string Description { get; set; }

        [DisplayName("CacheItemTenantAllowed")]
        public bool TenantAllowed { get; set; }
    }
}