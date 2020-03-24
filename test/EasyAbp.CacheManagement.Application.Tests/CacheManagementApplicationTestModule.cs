using Volo.Abp.Modularity;

namespace EasyAbp.CacheManagement
{
    [DependsOn(
        typeof(CacheManagementApplicationModule),
        typeof(CacheManagementDomainTestModule)
        )]
    public class CacheManagementApplicationTestModule : AbpModule
    {

    }
}
