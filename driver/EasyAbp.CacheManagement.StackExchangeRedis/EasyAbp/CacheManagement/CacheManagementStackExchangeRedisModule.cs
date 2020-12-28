using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.Modularity;

namespace EasyAbp.CacheManagement
{
    [DependsOn(
        typeof(AbpCachingStackExchangeRedisModule),
        typeof(CacheManagementDomainModule)
    )]
    public class CacheManagementStackExchangeRedisModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
