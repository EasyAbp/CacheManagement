using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.CacheManagement.EntityFrameworkCore
{
    public class CacheManagementHttpApiHostMigrationsDbContext : AbpDbContext<CacheManagementHttpApiHostMigrationsDbContext>
    {
        public CacheManagementHttpApiHostMigrationsDbContext(DbContextOptions<CacheManagementHttpApiHostMigrationsDbContext> options)
            : base(options)
        {
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureCacheManagement();
        }
    }
}
