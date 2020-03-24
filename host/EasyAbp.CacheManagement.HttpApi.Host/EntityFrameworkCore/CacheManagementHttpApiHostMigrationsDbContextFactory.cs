using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EasyAbp.CacheManagement.EntityFrameworkCore
{
    public class CacheManagementHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<CacheManagementHttpApiHostMigrationsDbContext>
    {
        public CacheManagementHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<CacheManagementHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("CacheManagement"));

            return new CacheManagementHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
