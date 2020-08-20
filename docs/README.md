# CacheManagement

[![NuGet](https://img.shields.io/nuget/v/EasyAbp.CacheManagement.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.CacheManagement.Domain.Shared)
[![NuGet Download](https://img.shields.io/nuget/dt/EasyAbp.CacheManagement.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.CacheManagement.Domain.Shared)
[![GitHub stars](https://img.shields.io/github/stars/EasyAbp/CacheManagement?style=social)](https://www.github.com/EasyAbp/CacheManagement)

An abp application module helps administrators to manage the app cache data.

## Online Demo

We have launched an online demo for this module: [https://cache.samples.easyabp.io](https://cache.samples.easyabp.io)

## Installation

1. Install the following NuGet packages. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/How-To.md#add-nuget-packages))

    * EasyAbp.CacheManagement.Application
    * EasyAbp.CacheManagement.Application.Contracts
    * EasyAbp.CacheManagement.Domain
    * EasyAbp.CacheManagement.Domain.Shared
    * EasyAbp.CacheManagement.EntityFrameworkCore
    * EasyAbp.CacheManagement.HttpApi
    * EasyAbp.CacheManagement.HttpApi.Client
    * (Optional) EasyAbp.CacheManagement.MongoDB
    * (Optional) EasyAbp.CacheManagement.Web

1. Add `DependsOn(typeof(CacheManagementXxxModule))` attribute to configure the module dependencies. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/How-To.md#add-module-dependencies))

1. Add `builder.ConfigureCacheManagement();` to the `OnModelCreating()` method in **MyProjectMigrationsDbContext.cs**.

1. Add EF Core migrations and update your database. See: [ABP document](https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=MVC#add-new-migration-update-the-database).


## Usage

1. Add permissions to the roles you want.

1. Add your own cache items.

1. Enjoy this wonderful module.

![CacheItems](/docs/images/CacheItems.png)
![EditCacheItem](/docs/images/EditCacheItem.png)
![CacheItemData](/docs/images/CacheItemData.png)

## Roadmap

- [ ] Cache values modification.
- [ ] More detailed documentations.
- [ ] More drivers.
- [ ] Unit tests.
