using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Volo.Abp.Caching;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;
using Volo.Abp.Threading;

namespace EasyAbp.CacheManagement.CacheItems
{
    [Dependency(ReplaceServices = true)]
    public class StackExchangeRedisCacheItemManager : DomainService, ICacheItemManager
    {
        private readonly IDistributedCache _distributedCache;
        private readonly IDistributedCacheKeyNormalizer _keyNormalizer;
        private readonly ICancellationTokenProvider _cancellationTokenProvider;
        private readonly ConnectionMultiplexer _connectionMultiplexer;

        public StackExchangeRedisCacheItemManager(
            IDistributedCache distributedCache,
            IDistributedCacheKeyNormalizer keyNormalizer,
            ICancellationTokenProvider cancellationTokenProvider,
            IConfiguration configuration)
        {
            if (!(distributedCache is RedisCache))
            {
                throw new DistributedCacheProviderInvalidException();
            }
            
            _distributedCache = distributedCache;
            _keyNormalizer = keyNormalizer;
            _cancellationTokenProvider = cancellationTokenProvider;
            _connectionMultiplexer = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
        }

        public async Task<IEnumerable<string>> GetKeysAsync(CacheItem cacheItem,
            CancellationToken cancellationToken = default)
        {
            var normalizedKey = GetNormalizedKey(cacheItem, "*");

            var endPoint = _connectionMultiplexer.GetEndPoints().First();

            var redisKeys = _connectionMultiplexer.GetServer(endPoint)
                .Keys(_connectionMultiplexer.GetDatabase().Database, normalizedKey);

            return redisKeys.Select(k => k.ToString());
        }

        public async Task ClearAllAsync(CancellationToken cancellationToken = default)
        {
            var endpoints = _connectionMultiplexer.GetEndPoints(true);
            
            foreach (var endpoint in endpoints)
            {
                var server = _connectionMultiplexer.GetServer(endpoint);
                
                await server.FlushDatabaseAsync(_connectionMultiplexer.GetDatabase().Database);
            }
        }

        public async Task ClearAsync(CacheItem cacheItem, CancellationToken cancellationToken = default)
        {
            var token = _cancellationTokenProvider.FallbackToProvider();
            
            var keys = await GetKeysAsync(cacheItem, token);
            
            foreach (var key in keys)
            {
                await _distributedCache.RemoveAsync(key, token);
            }
        }

        public async Task ClearSpecificAsync(CacheItem cacheItem, string cacheKey,
            CancellationToken cancellationToken = default)
        {
            var key = GetNormalizedKey(cacheItem, cacheKey);

            await _distributedCache.RemoveAsync(key, _cancellationTokenProvider.FallbackToProvider());
        }

        public async Task<string> GetValueAsync(string cacheKey, CancellationToken cancellationToken = default)
        {
            return await _distributedCache.GetStringAsync(cacheKey, _cancellationTokenProvider.FallbackToProvider());
        }

        protected virtual string GetNormalizedKey(CacheItem cacheItem, string cacheKey)
        {
            return _keyNormalizer.NormalizeKey(new DistributedCacheKeyNormalizeArgs(cacheKey, cacheItem.CacheName,
                cacheItem.IgnoreMultiTenancy));
        }
    }
}