using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared.Components;
using Volo.Abp.DependencyInjection;

namespace EasyAbp.CacheManagement
{
    [Dependency(ReplaceServices = true)]
    public class CacheManagementBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "CacheManagement";
    }
}
