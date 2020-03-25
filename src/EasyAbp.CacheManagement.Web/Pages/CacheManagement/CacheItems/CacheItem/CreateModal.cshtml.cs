using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem
{
    public class CreateModalModel : CacheManagementPageModel
    {
        [BindProperty]
        public CreateEditCacheItemViewModel CacheItem { get; set; }

        private readonly ICacheItemAppService _service;

        public CreateModalModel(ICacheItemAppService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(
                ObjectMapper.Map<CreateEditCacheItemViewModel, CreateUpdateCacheItemDto>(CacheItem));
            
            return NoContent();
        }
    }
}