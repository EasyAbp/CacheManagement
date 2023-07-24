using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Localization;
using EasyAbp.CacheManagement.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace EasyAbp.CacheManagement
{
    [DependsOn(
        typeof(AbpValidationModule),
        typeof(AbpDddDomainSharedModule)
    )]
    public class CacheManagementDomainSharedModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<CacheManagementDomainSharedModule>();
            });

            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Add<CacheManagementResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/EasyAbp/CacheManagement/Localization/CacheManagement");
            });

            Configure<AbpExceptionLocalizationOptions>(options =>
            {
                options.MapCodeNamespace("EasyAbp.CacheManagement", typeof(CacheManagementResource));
            });
        }
    }
}
