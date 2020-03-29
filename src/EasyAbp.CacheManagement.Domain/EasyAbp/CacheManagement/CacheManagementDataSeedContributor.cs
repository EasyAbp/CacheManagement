using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.CacheManagement
{
    public class CacheManagementDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly ICacheItemDataSeeder _cacheItemDataSeeder;

        public CacheManagementDataSeedContributor(
            ICacheItemDataSeeder cacheItemDataSeeder)
        {
            _cacheItemDataSeeder = cacheItemDataSeeder;
        }
        
        public virtual async Task SeedAsync(DataSeedContext context)
        {
            await _cacheItemDataSeeder.SeedAsync();
        }
    }
}