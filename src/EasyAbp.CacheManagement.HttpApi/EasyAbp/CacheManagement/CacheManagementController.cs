using EasyAbp.CacheManagement.Localization;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace EasyAbp.CacheManagement
{
    [Area(CacheManagementRemoteServiceConsts.ModuleName)]
    public abstract class CacheManagementController : AbpControllerBase
    {
        protected CacheManagementController()
        {
            LocalizationResource = typeof(CacheManagementResource);
        }
    }
}
