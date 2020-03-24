using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace EasyAbp.CacheManagement.Pages
{
    public class IndexModel : CacheManagementPageModel
    {
        public void OnGet()
        {
            
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}