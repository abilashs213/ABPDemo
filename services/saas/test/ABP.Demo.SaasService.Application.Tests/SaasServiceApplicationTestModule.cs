using ABP.Demo.SaasService.Application;
using Volo.Abp.Modularity;

namespace ABP.Demo.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationModule),
    typeof(SaasServiceDomainTestModule)
    )]
public class SaasServiceApplicationTestModule : AbpModule
{

}
