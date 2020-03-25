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
        public Guid CacheItemId { get; set; }

        [BindProperty]
        public ClearCacheItemViewModel ViewModel { get; set; }

        private readonly ICacheItemAppService _service;

        public ClearCacheModalModel(ICacheItemAppService service)
        {
            _service = service;
        }
        
        public async Task<IActionResult> OnPostAsync()
        {
            await _service.ClearAsync(new ClearCacheItemDto
            {
                CacheItemId = CacheItemId,
                CacheKey = ViewModel.CacheKey
            });
            
            return NoContent();
        }
    }
}