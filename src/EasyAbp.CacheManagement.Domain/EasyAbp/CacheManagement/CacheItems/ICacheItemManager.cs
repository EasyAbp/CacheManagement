using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.CacheManagement.CacheItems
{
    public interface ICacheItemManager
    {
        Task<IEnumerable<string>> GetKeysAsync(CacheItem cacheItem, CancellationToken cancellationToken = default);
        
        Task ClearAllAsync(CancellationToken cancellationToken = default);

        Task ClearAsync(CacheItem cacheItem, CancellationToken cancellationToken = default);
        
        Task ClearSpecificAsync(CacheItem cacheItem, string cacheKey, CancellationToken cancellationToken = default);
        
        Task<string> GetValueAsync(string cacheKey, CancellationToken cancellationToken = default);
    }
}