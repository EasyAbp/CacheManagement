using System;
using EasyAbp.CacheManagement.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace EasyAbp.CacheManagement.CacheItems
{
    public class CacheItemRepository : EfCoreRepository<ICacheManagementDbContext, CacheItem, Guid>, ICacheItemRepository
    {
        public CacheItemRepository(IDbContextProvider<ICacheManagementDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}