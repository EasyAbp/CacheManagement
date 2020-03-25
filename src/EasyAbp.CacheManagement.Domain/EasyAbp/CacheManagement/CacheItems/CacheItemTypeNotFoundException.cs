using Volo.Abp;

namespace EasyAbp.CacheManagement.CacheItems
{
    public class CacheItemTypeNotFoundException : BusinessException
    {
        public CacheItemTypeNotFoundException(string typeName) : base(message: $"Cache item type not found: {typeName}")
        {
            
        }
    }
}