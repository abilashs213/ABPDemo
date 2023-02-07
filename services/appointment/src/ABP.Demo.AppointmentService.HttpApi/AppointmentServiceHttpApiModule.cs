using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using ABP.Demo.AppointmentService.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace ABP.Demo.AppointmentService;

[DependsOn(
    typeof(AppointmentServiceApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class AppointmentServiceHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(AppointmentServiceHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<AppointmentServiceResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
