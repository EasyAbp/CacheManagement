using Volo.Abp.Reflection;

namespace EasyAbp.CacheManagement.Authorization
{
    public class CacheManagementPermissions
    {
        public const string GroupName = "CacheManagement";

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CacheManagementPermissions));
        }
    }
}