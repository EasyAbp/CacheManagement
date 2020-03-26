# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of projects
$projects = (

    "src/EasyAbp.CacheManagement.Application",
    "src/EasyAbp.CacheManagement.Application.Contracts",
    "src/EasyAbp.CacheManagement.Domain",
    "src/EasyAbp.CacheManagement.Domain.Shared",
    "src/EasyAbp.CacheManagement.EntityFrameworkCore",
    "src/EasyAbp.CacheManagement.HttpApi",
    "src/EasyAbp.CacheManagement.HttpApi.Client",
    "src/EasyAbp.CacheManagement.MongoDB",
    "src/EasyAbp.CacheManagement.Web",
    "driver/EasyAbp.CacheManagement.StackExchangeRedis"
)