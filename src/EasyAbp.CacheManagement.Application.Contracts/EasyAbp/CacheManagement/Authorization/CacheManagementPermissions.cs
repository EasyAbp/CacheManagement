using Volo.Abp.Reflection;

namespace EasyAbp.CacheManagement.Authorization
{
    public class CacheManagementPermissions
    {
        public const string GroupName = "EasyAbp.CacheManagement";
        
        public class CacheItems
        {
            public const string Default = GroupName + ".CacheItem";
            public const string Delete = Default + ".Delete";
            public const string Update = Default + ".Update";
            public const string Create = Default + ".Create";
            public const string ClearCache = Default + ".ClearCache";
            public const string ClearAllCache = Default + ".ClearAllCache";
        }

        public static string[] GetAll()
        {
            return ReflectionHelper.GetPublicConstantsRecursively(typeof(CacheManagementPermissions));
        }
    }
}