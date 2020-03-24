using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace EasyAbp.CacheManagement.MongoDB
{
    public class CacheManagementMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public CacheManagementMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}