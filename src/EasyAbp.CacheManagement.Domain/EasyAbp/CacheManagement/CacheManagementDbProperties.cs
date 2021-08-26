namespace EasyAbp.CacheManagement
{
    public static class CacheManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "EasyAbpCacheManagement";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "EasyAbpCacheManagement";
    }
}
