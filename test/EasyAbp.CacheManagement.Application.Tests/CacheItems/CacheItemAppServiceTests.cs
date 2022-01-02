using Shouldly;
using System.Threading.Tasks;
using Xunit;

namespace EasyAbp.CacheManagement.CacheItems
{
    public class CacheItemAppServiceTests : CacheManagementApplicationTestBase
    {
        private readonly ICacheItemAppService _cacheItemAppService;

        public CacheItemAppServiceTests()
        {
            _cacheItemAppService = GetRequiredService<ICacheItemAppService>();
        }
    }
}
