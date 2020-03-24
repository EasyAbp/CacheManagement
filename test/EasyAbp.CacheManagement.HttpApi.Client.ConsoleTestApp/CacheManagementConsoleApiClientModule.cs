using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace EasyAbp.CacheManagement
{
    [DependsOn(
        typeof(CacheManagementHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class CacheManagementConsoleApiClientModule : AbpModule
    {
        
    }
}
