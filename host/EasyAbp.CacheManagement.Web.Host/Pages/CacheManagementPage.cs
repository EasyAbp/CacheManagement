using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using EasyAbp.CacheManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.CacheManagement.Pages
{
    public abstract class CacheManagementPage : AbpPage
    {
        [RazorInject]
        public IHtmlLocalizer<CacheManagementResource> L { get; set; }
    }
}
