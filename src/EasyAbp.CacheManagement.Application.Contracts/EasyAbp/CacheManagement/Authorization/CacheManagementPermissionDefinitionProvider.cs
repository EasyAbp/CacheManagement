using EasyAbp.CacheManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace EasyAbp.CacheManagement.Authorization
{
    public class CacheManagementPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var moduleGroup = context.AddGroup(CacheManagementPermissions.GroupName, L("Permission:CacheManagement"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<CacheManagementResource>(name);
        }
    }
}