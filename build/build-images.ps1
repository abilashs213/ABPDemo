param ($version='latest')

$currentFolder = $PSScriptRoot
$slnFolder = Join-Path $currentFolder "../"
### Apps Folders
$angularAppFolder = Join-Path $slnFolder "apps/angular"
$authserverFolder = Join-Path $slnFolder "apps/auth-server/src/ABP.Demo.AuthServer"
$publicWebFolder = Join-Path $slnFolder "apps/public-web/src/ABP.Demo.PublicWeb"

### Microservice Folders
$identityServiceFolder = Join-Path $slnFolder "services/identity/src/ABP.Demo.IdentityService.HttpApi.Host"
$administrationServiceFolder = Join-Path $slnFolder "services/administration/src/ABP.Demo.AdministrationService.HttpApi.Host"
$saasServiceFolder = Join-Path $slnFolder "services/saas/src/ABP.Demo.SaasService.HttpApi.Host"
$productServiceFolder = Join-Path $slnFolder "services/product/src/ABP.Demo.ProductService.HttpApi.Host"

### Gateway Folders
$webGatewayFolder = Join-Path $slnFolder "gateways/web/src/ABP.Demo.WebGateway"
$webPublicGatewayFolder = Join-Path $slnFolder "gateways/web-public/src/ABP.Demo.PublicWebGateway"

### DB Migrator Folder
$dbmigratorFolder = Join-Path $slnFolder "shared/ABP.Demo.DbMigrator"

Write-Host "*** BUILDING DB MIGRATOR ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$dbmigratorFolder/Dockerfile" -t abp/demo-db-migrator:$version .

Write-Host "===== BUILDING MICROSERVICES =====" -ForegroundColor Yellow 
### IDENTITY-SERVICE
Write-Host "*** BUILDING IDENTITY-SERVICE ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$identityServiceFolder/Dockerfile" -t abp/demo-service-identity:$version .

### ADMINISTRATION-SERVICE
Write-Host "*** BUILDING ADMINISTRATION-SERVICE ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$administrationServiceFolder/Dockerfile" -t abp/demo-service-administration:$version .

### SAAS-SERVICE
Write-Host "*** BUILDING SAAS-SERVICE ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$saasServiceFolder/Dockerfile" -t abp/demo-service-saas:$version .

### PRODUCT-SERVICE
Write-Host "*** BUILDING PRODUCT-SERVICE ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$productServiceFolder/Dockerfile" -t abp/demo-service-product:$version .
Write-Host "===== COMPLETED BUILDING MICROSERVICES =====" -ForegroundColor Yellow 

Write-Host "===== BUILDING GATEWAYS =====" -ForegroundColor Yellow 
### WEB-GATEWAY
Write-Host "*** BUILDING WEB-GATEWAY ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$webGatewayFolder/Dockerfile" -t abp/demo-gateway-web:$version .

### PUBLICWEB-GATEWAY
Write-Host "*** BUILDING WEB-PUBLIC-GATEWAY ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$webPublicGatewayFolder/Dockerfile" -t abp/demo-gateway-web-public:$version .
Write-Host "===== COMPLETED BUILDING GATEWAYS =====" -ForegroundColor Yellow 

Write-Host "===== BUILDING APPLICATIONS =====" -ForegroundColor Yellow 
### AUTH-SERVER
Write-Host "*** BUILDING AUTH-SERVER ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$authserverFolder/Dockerfile" -t abp/demo-app-authserver:$version .

### PUBLIC-WEB
Write-Host "*** BUILDING WEB-PUBLIC ***" -ForegroundColor Green
Set-Location $slnFolder
docker build -f "$publicWebFolder/Dockerfile" -t abp/demo-app-public-web:$version .
### Angular WEB App
if (Test-Path -Path $angularAppFolder) {
    Write-Host "*** BUILDING ANGULAR WEB APPLICATION ***" -ForegroundColor Green
    Set-Location $angularAppFolder
    docker build -f "$angularAppFolder/Dockerfile" -t abp/demo-app-angular:$version .
}
Write-Host "===== COMPLETED BUILDING APPLICATIONS =====" -ForegroundColor Yellow

### ALL COMPLETED
Write-Host "ALL COMPLETED" -ForegroundColor Green
Set-Location $currentFolder