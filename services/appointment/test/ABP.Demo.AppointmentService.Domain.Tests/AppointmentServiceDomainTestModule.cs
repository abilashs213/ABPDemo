using ABP.Demo.AppointmentService.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace ABP.Demo.AppointmentService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(AppointmentServiceEntityFrameworkCoreTestModule)
    )]
public class AppointmentServiceDomainTestModule : AbpModule
{

}
