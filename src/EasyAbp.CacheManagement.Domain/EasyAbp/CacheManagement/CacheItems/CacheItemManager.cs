using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Abp.Caching;
using Volo.Abp.Domain.Services;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;

namespace EasyAbp.CacheManagement.CacheItems
{
    public class CacheItemManager : DomainService, ICacheItemManager
    {
        private readonly IDistributedCache _distributedCache;
        private readonly ICancellationTokenProvider _cancellationTokenProvider;
        private readonly IDistributedCacheKeyNormalizer _keyNormalizer;

        public CacheItemManager(
            IDistributedCache distributedCache,
            ICancellationTokenProvider cancellationTokenProvider,
            IDistributedCacheKeyNormalizer keyNormalizer)
        {
            _distributedCache = distributedCache;
            _cancellationTokenProvider = cancellationTokenProvider;
            _keyNormalizer = keyNormalizer;
        }
        
        public async Task ClearAsync(CacheItem cacheItem, string cacheKey, CancellationToken cancellationToken = default)
        {
            var type = Type.GetType(cacheItem.FullTypeName);

            if (type == null)
            {
                throw new CacheItemTypeNotFoundException(cacheItem.FullTypeName);
            }

            var normalizedKey = _keyNormalizer.NormalizeKey(
                new DistributedCacheKeyNormalizeArgs(
                    cacheKey,
                    CacheNameAttribute.GetCacheName(type),
                    type.IsDefined(typeof(IgnoreMultiTenancyAttribute), true)
                )
            );

            await _distributedCache.RemoveAsync(normalizedKey, _cancellationTokenProvider.FallbackToProvider());
        }
    }
}