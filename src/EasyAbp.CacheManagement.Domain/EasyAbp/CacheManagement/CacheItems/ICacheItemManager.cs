using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace EasyAbp.CacheManagement.CacheItems
{
    public interface ICacheItemManager : IDomainService
    {
        Task ClearAsync(CacheItem cacheItem, string cacheKey, CancellationToken cancellationToken = default);
    }
}