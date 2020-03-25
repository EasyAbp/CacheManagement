using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using EasyAbp.CacheManagement.CacheItems;

namespace EasyAbp.CacheManagement.EntityFrameworkCore
{
    [ConnectionStringName(CacheManagementDbProperties.ConnectionStringName)]
    public class CacheManagementDbContext : AbpDbContext<CacheManagementDbContext>, ICacheManagementDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<CacheItem> CacheItems { get; set; }

        public CacheManagementDbContext(DbContextOptions<CacheManagementDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureCacheManagement();
        }
    }
}
