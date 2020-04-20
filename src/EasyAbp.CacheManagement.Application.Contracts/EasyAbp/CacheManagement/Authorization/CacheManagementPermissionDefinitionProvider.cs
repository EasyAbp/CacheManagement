using EasyAbp.CacheManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace EasyAbp.CacheManagement.Authorization
{
    public class CacheManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var moduleGroup = context.AddGroup(CacheManagementPermissions.GroupName, L("Permission:CacheManagement"));

            var cacheItems = moduleGroup.AddPermission(CacheManagementPermissions.CacheItems.Default, L("Permission:CacheItem"));
            cacheItems.AddChild(CacheManagementPermissions.CacheItems.Create, L("Permission:Create"));
            cacheItems.AddChild(CacheManagementPermissions.CacheItems.Update, L("Permission:Update"));
            cacheItems.AddChild(CacheManagementPermissions.CacheItems.Delete, L("Permission:Delete"));
            cacheItems.AddChild(CacheManagementPermissions.CacheItems.ClearCache, L("Permission:ClearCache"));
            cacheItems.AddChild(CacheManagementPermissions.CacheItems.ClearAllCache, L("Permission:ClearAllCache"), MultiTenancySides.Host);
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CacheManagementResource>(name);
        }
    }
}