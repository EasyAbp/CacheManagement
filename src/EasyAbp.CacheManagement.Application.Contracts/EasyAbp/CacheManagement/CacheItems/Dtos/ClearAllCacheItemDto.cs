using System;
using System.ComponentModel;

namespace EasyAbp.CacheManagement.CacheItems.Dtos
{
    public class ClearAllCacheItemDto
    {
        [DisplayName("CacheItemId")]
        public Guid CacheItemId { get; set; }
    }
}