using System.Collections.Generic;
using System.Threading.Tasks;
using EasyAbp.CacheManagement.Authorization;
using EasyAbp.CacheManagement.Localization;
using Volo.Abp.UI.Navigation;

namespace EasyAbp.CacheManagement.Web.Menus
{
    public class CacheManagementMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenu(context);
            }
        }

        private async Task ConfigureMainMenu(MenuConfigurationContext context)
        {
            var l = context.GetLocalizer<CacheManagementResource>();

            var cacheManagementMenuItem = new ApplicationMenuItem(CacheManagementMenus.Prefix, l["Menu:CacheManagement"]);
            
            if (await context.IsGrantedAsync(CacheManagementPermissions.CacheItems.Default))
            {
                cacheManagementMenuItem.AddItem(
                    new ApplicationMenuItem(CacheManagementMenus.CacheItem, l["Menu:CacheItem"], "/CacheManagement/CacheItems/CacheItem")
                );
            }

            if (!cacheManagementMenuItem.Items.IsNullOrEmpty())
            {
                context.Menu.Items.Add(cacheManagementMenuItem);
            }
        }
    }
}
