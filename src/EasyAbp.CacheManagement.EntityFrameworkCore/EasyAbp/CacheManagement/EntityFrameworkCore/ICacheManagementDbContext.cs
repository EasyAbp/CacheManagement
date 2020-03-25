using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.CacheManagement.CacheItems;

namespace EasyAbp.CacheManagement.EntityFrameworkCore
{
    [ConnectionStringName(CacheManagementDbProperties.ConnectionStringName)]
    public interface ICacheManagementDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<CacheItem> CacheItems { get; set; }
    }
}
