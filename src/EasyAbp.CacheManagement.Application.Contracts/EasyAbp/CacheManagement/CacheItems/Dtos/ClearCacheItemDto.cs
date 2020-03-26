using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.CacheManagement.CacheItems.Dtos
{
    public class ClearCacheItemDto
    {
        [DisplayName("CacheItemId")]
        public Guid CacheItemId { get; set; }
    }
}