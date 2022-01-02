#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["host/EasyAbp.CacheManagement.Web.Unified/EasyAbp.CacheManagement.Web.Unified.csproj", "host/EasyAbp.CacheManagement.Web.Unified/"]
COPY ["src/EasyAbp.CacheManagement.Web/EasyAbp.CacheManagement.Web.csproj", "src/EasyAbp.CacheManagement.Web/"]
COPY ["src/EasyAbp.CacheManagement.HttpApi/EasyAbp.CacheManagement.HttpApi.csproj", "src/EasyAbp.CacheManagement.HttpApi/"]
COPY ["src/EasyAbp.CacheManagement.Application.Contracts/EasyAbp.CacheManagement.Application.Contracts.csproj", "src/EasyAbp.CacheManagement.Application.Contracts/"]
COPY ["src/EasyAbp.CacheManagement.Domain.Shared/EasyAbp.CacheManagement.Domain.Shared.csproj", "src/EasyAbp.CacheManagement.Domain.Shared/"]
COPY ["src/EasyAbp.CacheManagement.EntityFrameworkCore/EasyAbp.CacheManagement.EntityFrameworkCore.csproj", "src/EasyAbp.CacheManagement.EntityFrameworkCore/"]
COPY ["src/EasyAbp.CacheManagement.Domain/EasyAbp.CacheManagement.Domain.csproj", "src/EasyAbp.CacheManagement.Domain/"]
COPY ["src/EasyAbp.CacheManagement.Application/EasyAbp.CacheManagement.Application.csproj", "src/EasyAbp.CacheManagement.Application/"]
COPY ["driver/EasyAbp.CacheManagement.StackExchangeRedis/EasyAbp.CacheManagement.StackExchangeRedis.csproj", "driver/EasyAbp.CacheManagement.StackExchangeRedis/"]
COPY ["host/EasyAbp.CacheManagement.Host.Shared/EasyAbp.CacheManagement.Host.Shared.csproj", "host/EasyAbp.CacheManagement.Host.Shared/"]
COPY Directory.Build.props .
RUN dotnet restore "host/EasyAbp.CacheManagement.Web.Unified/EasyAbp.CacheManagement.Web.Unified.csproj"
COPY . .
WORKDIR "/src/host/EasyAbp.CacheManagement.Web.Unified"
RUN dotnet build "EasyAbp.CacheManagement.Web.Unified.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EasyAbp.CacheManagement.Web.Unified.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EasyAbp.CacheManagement.Web.Unified.dll"]
