using System;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem
{
    public class EditModalModel : CacheManagementPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        [BindProperty]
        public CreateEditCacheItemViewModel CacheItem { get; set; }

        private readonly ICacheItemAppService _service;

        public EditModalModel(ICacheItemAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var dto = await _service.GetAsync(Id);
            
            CacheItem = ObjectMapper.Map<CacheItemDto, CreateEditCacheItemViewModel>(dto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Id,
                ObjectMapper.Map<CreateEditCacheItemViewModel, CreateUpdateCacheItemDto>(CacheItem));
            
            return NoContent();
        }
    }
}