using System;
using System.ComponentModel;

namespace EasyAbp.CacheManagement.CacheItems.Dtos
{
    public class CacheItemDataDto
    {
        public Guid Id { get; set; }
        
        public string CacheKey { get; set; }
        
        public string CacheValue { get; set; }
    }
}