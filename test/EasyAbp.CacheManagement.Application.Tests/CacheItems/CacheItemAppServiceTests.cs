using Shouldly;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems.Dtos;
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

        [Fact]
        public async Task Should_Create_Update_And_Get_CacheItem()
        {
            // Create: exercises MapToEntityAsync(create) and the CacheItem -> CacheItemDto Mapperly mapper.
            var created = await _cacheItemAppService.CreateAsync(new CreateUpdateCacheItemDto
            {
                CacheName = "MyCache",
                DisplayName = "My Cache",
                Description = "desc",
                IgnoreMultiTenancy = true,
                TenantAllowed = true
            });

            created.Id.ShouldNotBe(default);
            created.CacheName.ShouldBe("MyCache");
            created.DisplayName.ShouldBe("My Cache");
            created.Description.ShouldBe("desc");
            created.IgnoreMultiTenancy.ShouldBeTrue();
            created.TenantAllowed.ShouldBeTrue();

            // Update: exercises the in-place MapToEntityAsync(update, entity) via CacheItem.Update(...).
            var updated = await _cacheItemAppService.UpdateAsync(created.Id, new CreateUpdateCacheItemDto
            {
                CacheName = "MyCache2",
                DisplayName = "My Cache 2",
                Description = "desc2",
                IgnoreMultiTenancy = false,
                TenantAllowed = true
            });

            updated.Id.ShouldBe(created.Id);
            updated.CacheName.ShouldBe("MyCache2");
            updated.DisplayName.ShouldBe("My Cache 2");
            updated.Description.ShouldBe("desc2");
            updated.IgnoreMultiTenancy.ShouldBeFalse();

            // Get: exercises the CacheItem -> CacheItemDto mapper against the persisted entity.
            var got = await _cacheItemAppService.GetAsync(created.Id);
            got.CacheName.ShouldBe("MyCache2");
            got.DisplayName.ShouldBe("My Cache 2");
            got.Description.ShouldBe("desc2");
        }
    }
}
