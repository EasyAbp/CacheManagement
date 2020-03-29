using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace EasyAbp.CacheManagement.CacheItems
{
    public class CacheItemDataSeeder : ICacheItemDataSeeder, ITransientDependency
    {
        private readonly IGuidGenerator _guidGenerator;
        private readonly ICacheItemRepository _repository;

        public CacheItemDataSeeder(
            IGuidGenerator guidGenerator,
            ICacheItemRepository repository)
        {
            _guidGenerator = guidGenerator;
            _repository = repository;
        }

        public virtual async Task SeedAsync()
        {
            await TryCreateAbpCacheItemsAsync();
        }

        protected virtual async Task TryCreateAbpCacheItemsAsync()
        {
            if (await _repository.GetCountAsync() == 0)
            {
                await CreateAbpCacheItemsAsync();
            }
        }

        protected virtual async Task CreateAbpCacheItemsAsync()
        {
            await _repository.InsertAsync(new CacheItem(
                id: _guidGenerator.Create(),
                cacheName: "Volo.Abp.IdentityServer.AllowedCorsOrigins",
                displayName: "AllowedCorsOrigins",
                description: "Volo.Abp.IdentityServer.AllowedCorsOrigins",
                ignoreMultiTenancy: false,
                tenantAllowed: false
            ));
            
            await _repository.InsertAsync(new CacheItem(
                id: _guidGenerator.Create(),
                cacheName: "Volo.Abp.SettingManagement.Setting",
                displayName: "Setting",
                description: "Volo.Abp.SettingManagement.Setting",
                ignoreMultiTenancy: true,
                tenantAllowed: false
            ));
            
            await _repository.InsertAsync(new CacheItem(
                id: _guidGenerator.Create(),
                cacheName: "Volo.Abp.AspNetCore.Mvc.UI.Bundling.Bundle",
                displayName: "Bundle",
                description: "Volo.Abp.AspNetCore.Mvc.UI.Bundling.Bundle",
                ignoreMultiTenancy: false,
                tenantAllowed: false
            ));
            
            await _repository.InsertAsync(new CacheItem(
                id: _guidGenerator.Create(),
                cacheName: "Volo.Abp.FeatureManagement.FeatureValue",
                displayName: "FeatureValue",
                description: "Volo.Abp.FeatureManagement.FeatureValue",
                ignoreMultiTenancy: true,
                tenantAllowed: false
            ));
            
            await _repository.InsertAsync(new CacheItem(
                id: _guidGenerator.Create(),
                cacheName: "Volo.Abp.PermissionManagement.PermissionGrant",
                displayName: "PermissionGrant",
                description: "Volo.Abp.PermissionManagement.PermissionGrant",
                ignoreMultiTenancy: false,
                tenantAllowed: false
            ));
        }
    }
}