using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace EasyAbp.CacheManagement
{
    [Dependency(ReplaceServices = true)]
    public class CacheManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CacheManagement";
    }
}
