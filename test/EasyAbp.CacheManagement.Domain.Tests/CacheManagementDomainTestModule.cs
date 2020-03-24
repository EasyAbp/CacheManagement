using EasyAbp.CacheManagement.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace EasyAbp.CacheManagement
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(CacheManagementEntityFrameworkCoreTestModule)
        )]
    public class CacheManagementDomainTestModule : AbpModule
    {
        
    }
}
