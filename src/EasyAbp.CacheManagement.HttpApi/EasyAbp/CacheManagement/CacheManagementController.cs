using EasyAbp.CacheManagement.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.CacheManagement
{
    public abstract class CacheManagementController : AbpController
    {
        protected CacheManagementController()
        {
            LocalizationResource = typeof(CacheManagementResource);
        }
    }
}
