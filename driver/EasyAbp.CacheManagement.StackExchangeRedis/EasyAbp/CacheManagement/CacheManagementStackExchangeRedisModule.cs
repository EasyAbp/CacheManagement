using Volo.Abp.Modularity;

namespace EasyAbp.CacheManagement
{
    [DependsOn(
        typeof(CacheManagementDomainModule)
        )]
    public class CacheManagementStackExchangeRedisModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
        }
    }
}
