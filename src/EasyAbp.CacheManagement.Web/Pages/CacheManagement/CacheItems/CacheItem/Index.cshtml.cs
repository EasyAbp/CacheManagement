using System.Threading.Tasks;

namespace EasyAbp.CacheManagement.Web.Pages.CacheManagement.CacheItems.CacheItem
{
    public class IndexModel : CacheManagementPageModel
    {
        public async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
