using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.CacheManagement
{
    [DependsOn(
        typeof(CacheManagementApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class CacheManagementHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = CacheManagementRemoteServiceConsts.RemoteServiceName;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(CacheManagementApplicationContractsModule).Assembly,
                RemoteServiceName
            );
            
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CacheManagementApplicationContractsModule>();
            });
        }
    }
}
