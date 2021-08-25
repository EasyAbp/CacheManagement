using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;
using Volo.Abp.Threading;

namespace EasyAbp.CacheManagement.CacheItems
{
    [Dependency(ReplaceServices = true)]
    public class StackExchangeRedisCacheItemManager : ICacheItemManager, ISingletonDependency
    {
        private IDatabase _redisDatabase;
        
        private readonly RedisCache _redisCache;
        private readonly IDistributedCacheKeyNormalizer _keyNormalizer;
        private readonly ICancellationTokenProvider _cancellationTokenProvider;

        protected IDatabase RedisDatabase => GetRedisDatabase();
        
        public StackExchangeRedisCacheItemManager(
            IDistributedCache distributedCache,
            IDistributedCacheKeyNormalizer keyNormalizer,
            ICancellationTokenProvider cancellationTokenProvider)
        {
            if (distributedCache is not RedisCache redisCache)
            {
                throw new DistributedCacheProviderInvalidException();
            }
            
            _redisCache = redisCache;
            _keyNormalizer = keyNormalizer;
            _cancellationTokenProvider = cancellationTokenProvider;
        }

        private IDatabase GetRedisDatabase()
        {
            if (_redisDatabase == null)
            {
                var redisDatabaseField =
                    typeof(RedisCache).GetField("_cache", BindingFlags.Instance | BindingFlags.NonPublic);
                
                _redisDatabase = redisDatabaseField!.GetValue(_redisCache) as IDatabase;
            }

            return _redisDatabase;
        }

        public virtual Task<IEnumerable<string>> GetKeysAsync(CacheItem cacheItem,
            CancellationToken cancellationToken = default)
        {
            var normalizedKey = GetNormalizedKey(cacheItem, "*");

            return Task.FromResult(RedisDatabase.Multiplexer.GetServer(RedisDatabase.Multiplexer.GetEndPoints().First())
                .Keys(RedisDatabase.Database, normalizedKey).Select(k => k.ToString()));
        }

        public virtual async Task ClearAllAsync(CancellationToken cancellationToken = default)
        {
            var endpoints = _redisDatabase.Multiplexer.GetEndPoints(true);
            
            foreach (var endpoint in endpoints)
            {
                var server = _redisDatabase.Multiplexer.GetServer(endpoint);
                
                await server.FlushDatabaseAsync(_redisDatabase.Database);
            }
        }

        public virtual async Task ClearAsync(CacheItem cacheItem, CancellationToken cancellationToken = default)
        {
            var token = _cancellationTokenProvider.FallbackToProvider();
            
            var keys = await GetKeysAsync(cacheItem, token);
            
            foreach (var key in keys)
            {
                await _redisCache.RemoveAsync(key, token);
            }
        }

        public virtual async Task ClearSpecificAsync(CacheItem cacheItem, string cacheKey,
            CancellationToken cancellationToken = default)
        {
            var key = GetNormalizedKey(cacheItem, cacheKey);

            await _redisCache.RemoveAsync(key, _cancellationTokenProvider.FallbackToProvider());
        }

        public virtual async Task<string> GetValueAsync(string cacheKey, CancellationToken cancellationToken = default)
        {
            return await _redisCache.GetStringAsync(cacheKey, _cancellationTokenProvider.FallbackToProvider());
        }

        protected virtual string GetNormalizedKey(CacheItem cacheItem, string cacheKey)
        {
            return _keyNormalizer.NormalizeKey(new DistributedCacheKeyNormalizeArgs(cacheKey, cacheItem.CacheName,
                cacheItem.IgnoreMultiTenancy));
        }
    }
}