using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace EasyAbp.CacheManagement
{
    [DependsOn(
        typeof(CacheManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CacheManagementHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "EasyAbpCacheManagement";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CacheManagementApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
