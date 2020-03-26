using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.CacheManagement.CacheItems
{
    public class CacheItem : AggregateRoot<Guid>
    {
        [NotNull]
        public virtual string CacheName { get; protected set; }
     
        [NotNull]
        public virtual string DisplayName { get; protected set; }
        
        [CanBeNull]
        public virtual string Description { get; protected set; }
        
        public virtual bool IgnoreMultiTenancy { get; protected set; }

        public virtual bool TenantAllowed { get; protected set; }

        protected CacheItem()
        {
        }

        public CacheItem(
            Guid id,
            [NotNull] string cacheName,
            [NotNull] string displayName,
            [CanBeNull] string description,
            bool ignoreMultiTenancy,
            bool tenantAllowed
        ) :base(id)
        {
            CacheName = cacheName;
            DisplayName = displayName;
            Description = description;
            IgnoreMultiTenancy = ignoreMultiTenancy;
            TenantAllowed = tenantAllowed;
        }
    }
}
