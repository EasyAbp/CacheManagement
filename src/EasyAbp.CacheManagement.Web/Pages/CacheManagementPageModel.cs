using EasyAbp.CacheManagement.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace EasyAbp.CacheManagement.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class CacheManagementPageModel : AbpPageModel
    {
        protected CacheManagementPageModel()
        {
            LocalizationResourceType = typeof(CacheManagementResource);
            ObjectMapperContext = typeof(CacheManagementWebModule);
        }
    }
}