using System;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace EasyAbp.CacheManagement.EntityFrameworkCore.CacheItems
{
    public class CacheItemRepositoryTests : CacheManagementEntityFrameworkCoreTestBase
    {
        private readonly IRepository<CacheItem, Guid> _cacheItemRepository;

        public CacheItemRepositoryTests()
        {
            _cacheItemRepository = GetRequiredService<IRepository<CacheItem, Guid>>();
        }

        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange

                // Act

                //Assert
            });
        }
    }
}
