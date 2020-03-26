using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.CacheManagement.CacheItems.Dtos
{
    public class ClearSpecificCacheItemDto : ClearCacheItemDto
    {
        [Required]
        [DisplayName("CacheItemCacheKey")]
        public string CacheKey { get; set; }
    }
}