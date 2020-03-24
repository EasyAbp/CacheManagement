namespace EasyAbp.CacheManagement
{
    public static class CacheManagementDbProperties
    {
        public static string DbTablePrefix { get; set; } = "CacheManagement";

        public static string DbSchema { get; set; } = null;

        public const string ConnectionStringName = "CacheManagement";
    }
}
