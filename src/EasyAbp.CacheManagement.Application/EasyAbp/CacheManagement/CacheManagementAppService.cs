using EasyAbp.CacheManagement.Localization;
using Volo.Abp.Application.Services;

namespace EasyAbp.CacheManagement
{
    public abstract class CacheManagementAppService : ApplicationService
    {
        protected CacheManagementAppService()
        {
            LocalizationResource = typeof(CacheManagementResource);
            ObjectMapperContext = typeof(CacheManagementApplicationModule);
        }
    }
}
