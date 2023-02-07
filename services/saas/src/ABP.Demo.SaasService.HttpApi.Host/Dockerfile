FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# It's important to keep lines from here down to "COPY . ." identical in all Dockerfiles
# to take advantage of Docker's build cache, to speed up local container builds
COPY "ABP.Demo.sln" "ABP.Demo.sln"

# Applications
COPY "apps/auth-server/src/ABP.Demo.AuthServer/ABP.Demo.AuthServer.csproj" "apps/auth-server/src/ABP.Demo.AuthServer/ABP.Demo.AuthServer.csproj"
COPY "apps/public-web/src/ABP.Demo.PublicWeb/ABP.Demo.PublicWeb.csproj" "apps/public-web/src/ABP.Demo.PublicWeb/ABP.Demo.PublicWeb.csproj"
COPY *"apps/blazor/src/ABP.Demo.Blazor/ABP.Demo.Blazor.csproj" "apps/blazor/src/ABP.Demo.Blazor/ABP.Demo.Blazor.csproj"
COPY *"apps/blazor/src/ABP.Demo.Blazor.Server/ABP.Demo.Blazor.Server.csproj" "apps/blazor/src/ABP.Demo.Blazor.Server/ABP.Demo.Blazor.Server.csproj"
COPY *"apps/web/src/ABP.Demo.Web/ABP.Demo.Web.csproj" "apps/web/src/ABP.Demo.Web/ABP.Demo.Web.csproj"

# Shared Projects
COPY "shared/ABP.Demo.DbMigrator/ABP.Demo.DbMigrator.csproj" "shared/ABP.Demo.DbMigrator/ABP.Demo.DbMigrator.csproj"
COPY "shared/ABP.Demo.Shared.Hosting/ABP.Demo.Shared.Hosting.csproj" "shared/ABP.Demo.Shared.Hosting/ABP.Demo.Shared.Hosting.csproj"
COPY "shared/ABP.Demo.Shared.Hosting.Gateways/ABP.Demo.Shared.Hosting.Gateways.csproj" "shared/ABP.Demo.Shared.Hosting.Gateways/ABP.Demo.Shared.Hosting.Gateways.csproj"
COPY "shared/ABP.Demo.Shared.Hosting.Microservices/ABP.Demo.Shared.Hosting.Microservices.csproj" "shared/ABP.Demo.Shared.Hosting.Microservices/ABP.Demo.Shared.Hosting.Microservices.csproj"
COPY "shared/ABP.Demo.Shared.Hosting.AspNetCore/ABP.Demo.Shared.Hosting.AspNetCore.csproj" "shared/ABP.Demo.Shared.Hosting.AspNetCore/ABP.Demo.Shared.Hosting.AspNetCore.csproj"
COPY "shared/ABP.Demo.Shared.Hosting/ABP.Demo.Shared.Hosting.csproj" "shared/ABP.Demo.Shared.Hosting/ABP.Demo.Shared.Hosting.csproj"
COPY "shared/ABP.Demo.Shared.Localization/ABP.Demo.Shared.Localization.csproj" "shared/ABP.Demo.Shared.Localization/ABP.Demo.Shared.Localization.csproj"

# Microservices
COPY "services/administration/src/ABP.Demo.AdministrationService.HttpApi.Host/ABP.Demo.AdministrationService.HttpApi.Host.csproj" "services/administration/src/ABP.Demo.AdministrationService.HttpApi.Host/ABP.Demo.AdministrationService.HttpApi.Host.csproj"
COPY "services/identity/src/ABP.Demo.IdentityService.HttpApi.Host/ABP.Demo.IdentityService.HttpApi.Host.csproj" "services/identity/src/ABP.Demo.IdentityService.HttpApi.Host/ABP.Demo.IdentityService.HttpApi.Host.csproj"
COPY "services/saas/src/ABP.Demo.SaasService.HttpApi.Host/ABP.Demo.SaasService.HttpApi.Host.csproj" "services/saas/src/ABP.Demo.SaasService.HttpApi.Host/ABP.Demo.SaasService.HttpApi.Host.csproj"
COPY "services/product/src/ABP.Demo.ProductService.HttpApi.Host/ABP.Demo.ProductService.HttpApi.Host.csproj" "services/product/src/ABP.Demo.ProductService.HttpApi.Host/ABP.Demo.ProductService.HttpApi.Host.csproj"
# Gateways
COPY "gateways/web/src/ABP.Demo.WebGateway/ABP.Demo.WebGateway.csproj" "gateways/web/src/ABP.Demo.WebGateway/ABP.Demo.WebGateway.csproj"
COPY "gateways/web-public/src/ABP.Demo.PublicWebGateway/ABP.Demo.PublicWebGateway.csproj" "gateways/web-public/src/ABP.Demo.PublicWebGateway/ABP.Demo.PublicWebGateway.csproj"

COPY "NuGet.Config" "NuGet.Config"

RUN dotnet restore "ABP.Demo.sln"

COPY . .
WORKDIR "/src/services/saas/src/ABP.Demo.SaasService.HttpApi.Host"
RUN dotnet publish -c Release -o /app
# Should be used after .net6 is out of preview for better performance
# RUN dotnet publish --no-restore -c Release -o /app

FROM build AS publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ABP.Demo.SaasService.HttpApi.Host.dll"]