using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem.ViewModels
{
    public class CreateEditCacheItemViewModel
    {
        [Required]
        [DisplayName("CacheItemCacheName")]
        public string CacheName { get; set; }

        [Required]
        [DisplayName("CacheItemDisplayName")]
        public string DisplayName { get; set; }

        [DisplayName("CacheItemDescription")]
        [TextArea(Rows = 4)]
        public string Description { get; set; }

        [DisplayName("CacheItemIgnoreMultiTenancy")]
        public bool IgnoreMultiTenancy { get; set; }
        
        [DisplayName("CacheItemTenantAllowed")]
        public bool TenantAllowed { get; set; }
    }
}