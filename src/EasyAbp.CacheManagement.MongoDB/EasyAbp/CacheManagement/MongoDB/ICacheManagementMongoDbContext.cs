using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EasyAbp.CacheManagement.MongoDB
{
    [ConnectionStringName(CacheManagementDbProperties.ConnectionStringName)]
    public interface ICacheManagementMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
