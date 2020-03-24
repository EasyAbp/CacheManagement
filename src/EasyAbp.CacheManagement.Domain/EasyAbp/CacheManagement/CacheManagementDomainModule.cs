using Volo.Abp.Modularity;

namespace EasyAbp.CacheManagement
{
    [DependsOn(
        typeof(CacheManagementDomainSharedModule)
        )]
    public class CacheManagementDomainModule : AbpModule
    {

    }
}
