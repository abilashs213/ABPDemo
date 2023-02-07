using Volo.Abp.Modularity;

namespace ABP.Demo.AppointmentService;

[DependsOn(
    typeof(AppointmentServiceApplicationModule),
    typeof(AppointmentServiceDomainTestModule)
    )]
public class AppointmentServiceApplicationTestModule : AbpModule
{

}
