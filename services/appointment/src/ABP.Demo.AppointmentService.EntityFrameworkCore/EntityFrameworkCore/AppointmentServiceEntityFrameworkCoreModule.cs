using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;

namespace ABP.Demo.AppointmentService.EntityFrameworkCore;

[DependsOn(
    typeof(AbpEntityFrameworkCoreSqlServerModule),
    typeof(AbpEntityFrameworkCoreModule),
    typeof(AppointmentServiceDomainModule)
)]
public class AppointmentServiceEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AppointmentServiceEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AppointmentServiceDbContext>(options =>
        {
                /* Remove "includeAllEntities: true" to create
                 * default repositories only for aggregate roots */
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.Configure<AppointmentServiceDbContext>(c =>
            {
                c.UseSqlServer(b =>
                {
                    b.MigrationsHistoryTable("__AppointmentService_Migrations");
                });
            });
        });
    }
}
