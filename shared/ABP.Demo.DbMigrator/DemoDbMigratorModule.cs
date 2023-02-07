using ABP.Demo.AdministrationService;
using ABP.Demo.AdministrationService.EntityFrameworkCore;
using ABP.Demo.IdentityService;
using ABP.Demo.IdentityService.EntityFrameworkCore;
using ABP.Demo.ProductService;
using ABP.Demo.ProductService.EntityFrameworkCore;
using ABP.Demo.SaasService;
using ABP.Demo.SaasService.EntityFrameworkCore;
using ABP.Demo.Shared.Hosting;
using Volo.Abp.Modularity;

namespace ABP.Demo.DbMigrator;

[DependsOn(
    typeof(DemoSharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule)
)]
public class DemoDbMigratorModule : AbpModule
{

}
