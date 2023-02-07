using Volo.Abp.Domain;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace ABP.Demo.AppointmentService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AbpCachingModule),
    typeof(AppointmentServiceDomainSharedModule)
)]
public class AppointmentServiceDomainModule : AbpModule
{
}
