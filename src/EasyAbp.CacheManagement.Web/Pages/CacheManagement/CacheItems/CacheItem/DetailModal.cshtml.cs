using System;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems;
using EasyAbp.CacheManagement.CacheItems.Dtos;
using EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem
{
    public class DetailModalModel : CacheManagementPageModel
    {
        [BindProperty]
        public CacheItemDataViewModel Data { get; set; }

        private readonly ICacheItemAppService _service;

        public DetailModalModel(ICacheItemAppService service)
        {
            _service = service;
        }

        public async Task OnGetAsync(Guid cacheItemId, string cacheKey)
        {
            var data = await _service.GetDataAsync(cacheItemId, cacheKey);
            
            Data = new CacheItemDataViewModel
            {
                CacheKey = data.CacheKey,
                CacheValue = data.CacheValue
            };
        }
    }
}