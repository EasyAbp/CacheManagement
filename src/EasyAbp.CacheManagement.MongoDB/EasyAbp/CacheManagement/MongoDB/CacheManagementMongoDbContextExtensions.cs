using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace EasyAbp.CacheManagement.MongoDB
{
    public static class CacheManagementMongoDbContextExtensions
    {
        public static void ConfigureCacheManagement(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new CacheManagementMongoModelBuilderConfigurationOptions(
                CacheManagementDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);
        }
    }
}