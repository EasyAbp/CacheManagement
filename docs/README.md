# CacheManagement

[![ABP version](https://img.shields.io/badge/dynamic/xml?style=flat-square&color=yellow&label=abp&query=%2F%2FProject%2FPropertyGroup%2FAbpVersion&url=https%3A%2F%2Fraw.githubusercontent.com%2FEasyAbp%2FCacheManagement%2Fmaster%2FDirectory.Build.props)](https://abp.io)
[![NuGet](https://img.shields.io/nuget/v/EasyAbp.CacheManagement.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.CacheManagement.Domain.Shared)
[![NuGet Download](https://img.shields.io/nuget/dt/EasyAbp.CacheManagement.Domain.Shared.svg?style=flat-square)](https://www.nuget.org/packages/EasyAbp.CacheManagement.Domain.Shared)
[![Discord online](https://badgen.net/discord/online-members/S6QaezrCRq?label=Discord)](https://discord.gg/S6QaezrCRq)
[![GitHub stars](https://img.shields.io/github/stars/EasyAbp/CacheManagement?style=social)](https://www.github.com/EasyAbp/CacheManagement)

An abp application module helps administrators to manage the app cache data.

## Online Demo

We have launched an online demo for this module: [https://cache.samples.easyabp.io](https://cache.samples.easyabp.io)

## Installation

1. Install the following NuGet packages. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-nuget-packages))

    * EasyAbp.CacheManagement.Application
    * EasyAbp.CacheManagement.Application.Contracts
    * EasyAbp.CacheManagement.Domain
    * EasyAbp.CacheManagement.Domain.Shared
    * EasyAbp.CacheManagement.EntityFrameworkCore
    * EasyAbp.CacheManagement.HttpApi
    * EasyAbp.CacheManagement.HttpApi.Client
    * (Optional) EasyAbp.CacheManagement.MongoDB
    * (Optional) EasyAbp.CacheManagement.Web
    * (Optional) EasyAbp.CacheManagement.StackExchangeRedis

1. Add `DependsOn(typeof(CacheManagementXxxModule))` attribute to configure the module dependencies. ([see how](https://github.com/EasyAbp/EasyAbpGuide/blob/master/docs/How-To.md#add-module-dependencies))

1. Add `builder.ConfigureCacheManagement();` to the `OnModelCreating()` method in **MyProjectMigrationsDbContext.cs**.

1. Add EF Core migrations and update your database. See: [ABP document](https://docs.abp.io/en/abp/latest/Tutorials/Part-1?UI=MVC&DB=EF#add-database-migration).


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
