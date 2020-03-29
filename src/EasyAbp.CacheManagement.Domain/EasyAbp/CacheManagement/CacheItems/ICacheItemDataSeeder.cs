using System.Threading.Tasks;

namespace EasyAbp.CacheManagement.CacheItems
{
    public interface ICacheItemDataSeeder
    {
        Task SeedAsync();
    }
}