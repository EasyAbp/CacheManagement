using System;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem
{
    public class ClearCacheModalModel : CacheManagementPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public Guid Id { get; set; }

        public ClearCacheItemViewModel ViewModel { get; set; }

        private readonly ICacheItemAppService _service;

        public ClearCacheModalModel(ICacheItemAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var cacheItemDto = await _service.GetAsync(Id);
            
            ViewModel = new ClearCacheItemViewModel
            {
                DisplayName = cacheItemDto.DisplayName
            };
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            await _service.ClearAsync(Id);
            
            return NoContent();
        }
    }
}