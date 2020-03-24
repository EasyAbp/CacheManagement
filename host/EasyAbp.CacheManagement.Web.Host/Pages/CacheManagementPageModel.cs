using EasyAbp.CacheManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.CacheManagement.Pages
{
    public abstract class CacheManagementPageModel : AbpPageModel
    {
        protected CacheManagementPageModel()
        {
            LocalizationResourceType = typeof(CacheManagementResource);
        }
    }
}