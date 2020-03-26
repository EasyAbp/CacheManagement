using System.ComponentModel;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem.ViewModels
{
    public class CacheItemDataViewModel
    {
        [DisabledInput]
        [DisplayName("CacheItemCacheKey")]
        public string CacheKey { get; set; }
        
        [DisabledInput]
        [TextArea(Rows = 4)]
        [DisplayName("CacheItemCacheValue")]
        public string CacheValue { get; set; }
    }
}