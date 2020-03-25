using System;
using Volo.Abp.Domain.Repositories;

namespace EasyAbp.CacheManagement.CacheItems
{
    public interface ICacheItemRepository : IRepository<CacheItem, Guid>
    {
    }
}