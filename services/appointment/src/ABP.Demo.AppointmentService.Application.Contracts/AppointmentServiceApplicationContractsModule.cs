using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace ABP.Demo.AppointmentService;

[DependsOn(
    typeof(AppointmentServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class AppointmentServiceApplicationContractsModule : AbpModule
{

}
