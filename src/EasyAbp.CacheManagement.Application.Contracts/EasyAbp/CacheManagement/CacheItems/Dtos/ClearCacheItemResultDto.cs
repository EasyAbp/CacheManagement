using System;

namespace EasyAbp.CacheManagement.CacheItems.Dtos
{
    public class ClearCacheItemResultDto
    {
        public Guid CacheItemId { get; set; }
        
        public long Count { get; set; }
    }
}