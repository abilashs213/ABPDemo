using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;

namespace ABP.Demo.Shared.Hosting.AspNetCore;

[DependsOn(
    typeof(DemoSharedHostingModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
)]
public class DemoSharedHostingAspNetCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}
