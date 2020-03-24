using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.CacheManagement.MongoDB
{
    [ConnectionStringName(CacheManagementDbProperties.ConnectionStringName)]
    public class CacheManagementMongoDbContext : AbpMongoDbContext, ICacheManagementMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureCacheManagement();
        }
    }
}