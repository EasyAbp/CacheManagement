using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.CacheManagement.EntityFrameworkCore
{
    [ConnectionStringName(CacheManagementDbProperties.ConnectionStringName)]
    public interface ICacheManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
    }
}