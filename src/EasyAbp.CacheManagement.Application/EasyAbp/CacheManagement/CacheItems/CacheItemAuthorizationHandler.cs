using System.Threading.Tasks;
using EasyAbp.CacheManagement.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.CacheManagement.CacheItems
{
    public class CacheItemAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, CacheItem>
    {
        private readonly ICurrentTenant _currentTenant;

        public CacheItemAuthorizationHandler(
            ICurrentTenant currentTenant)
        {
            _currentTenant = currentTenant;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
            OperationAuthorizationRequirement requirement, CacheItem resource)
        {
            if (requirement.Name.Equals(CacheManagementPermissions.CacheItems.ClearCache) &&
                HasClearCachePermission(context, resource))
            {
                context.Succeed(requirement);
                return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }
        
        protected virtual bool HasClearCachePermission(AuthorizationHandlerContext context, CacheItem resource)
        {
            return resource.TenantAllowed || _currentTenant.GetMultiTenancySide() == MultiTenancySides.Host;
        }
    }
}