using System;
using Volo.Abp.Data;
using Volo.Abp.Modularity;

namespace EasyAbp.CacheManagement.MongoDB
{
    [DependsOn(
        typeof(CacheManagementTestBaseModule),
        typeof(CacheManagementMongoDbModule)
        )]
    public class CacheManagementMongoDbTestModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbConnectionOptions>(options =>
            {
                options.ConnectionStrings.Default = MongoDbFixture.GetRandomConnectionString();
            });
        }
    }
}