using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Application;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;

namespace ABP.Demo.AppointmentService;

[DependsOn(
    typeof(AppointmentServiceDomainModule),
    typeof(AppointmentServiceApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class AppointmentServiceApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<AppointmentServiceApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<AppointmentServiceApplicationModule>(validate: true);
        });
    }
}
