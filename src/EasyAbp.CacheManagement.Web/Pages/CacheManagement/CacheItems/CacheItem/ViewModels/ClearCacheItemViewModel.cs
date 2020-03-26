using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem.ViewModels
{
    public class ClearCacheItemViewModel
    {
        [DisabledInput]
        [DisplayName("CacheItemDisplayName")]
        public string DisplayName { get; set; }
    }
}