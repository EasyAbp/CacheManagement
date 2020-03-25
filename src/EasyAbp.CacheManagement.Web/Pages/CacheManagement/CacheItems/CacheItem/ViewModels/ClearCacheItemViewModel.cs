using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem.ViewModels
{
    public class ClearCacheItemViewModel
    {
        [Required]
        [DisplayName("CacheItemCacheKey")]
        public string CacheKey { get; set; }
    }
}