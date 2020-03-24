using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace EasyAbp.CacheManagement.EntityFrameworkCore
{
    public class CacheManagementModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public CacheManagementModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}