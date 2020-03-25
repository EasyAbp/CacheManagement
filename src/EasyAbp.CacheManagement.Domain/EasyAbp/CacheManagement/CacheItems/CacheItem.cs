using System;
using JetBrains.Annotations;
using Volo.Abp.Domain.Entities;

namespace EasyAbp.CacheManagement.CacheItems
{
    public class CacheItem : AggregateRoot<Guid>
    {
        [NotNull]
        public virtual string FullTypeName { get; protected set; }
     
        [NotNull]
        public virtual string DisplayName { get; protected set; }
        
        [CanBeNull]
        public virtual string Description { get; protected set; }

        public virtual bool TenantAllowed { get; protected set; }

        protected CacheItem()
        {
        }

        public CacheItem(
            Guid id,
            [NotNull] string fullTypeName,
            [NotNull] string displayName,
            [CanBeNull] string description,
            bool tenantAllowed
        ) :base(id)
        {
            FullTypeName = fullTypeName;
            DisplayName = displayName;
            Description = description;
            TenantAllowed = tenantAllowed;
        }
    }
}
