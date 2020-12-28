using System;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.CacheItems;
using EasyAbp.CacheManagement.CacheItems.Dtos;

namespace EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem
{
    public class KeyListModel : CacheManagementPageModel
    {
        private readonly ICacheItemAppService _service;
        
        public CacheItemDto CacheItem { get; set; }

        public KeyListModel(ICacheItemAppService service)
        {
            _service = service;
        }
        
        public async Task OnGetAsync(Guid id)
        {
            CacheItem = await _service.GetAsync(id);

            await Task.CompletedTask;
        }
    }
}
