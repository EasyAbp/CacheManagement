using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.CacheManagement.CacheItems
{
    /* A no-op cache manager so the CacheItemAppService can be resolved in application-layer
     * tests without a real cache driver (e.g. StackExchangeRedis). It only needs to satisfy
     * the constructor dependency; the standard CRUD paths under test do not call it. */
    public class FakeCacheItemManager : ICacheItemManager, ISingletonDependency
    {
        public Task<IEnumerable<string>> GetKeysAsync(CacheItem cacheItem, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Enumerable.Empty<string>());
        }

        public Task ClearAllAsync(CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task ClearAsync(CacheItem cacheItem, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task ClearSpecificAsync(CacheItem cacheItem, string cacheKey, CancellationToken cancellationToken = default)
        {
            return Task.CompletedTask;
        }

        public Task<string> GetValueAsync(string cacheKey, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(string.Empty);
        }
    }
}
