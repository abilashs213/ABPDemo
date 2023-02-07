using ABP.Demo.AppointmentService.Localization;
using Volo.Abp.Commercial.SuiteTemplates;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ABP.Demo.AppointmentService;

[DependsOn(
    typeof(VoloAbpCommercialSuiteTemplatesModule),
    typeof(AbpValidationModule)
)]
public class AppointmentServiceDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AppointmentServiceModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AppointmentServiceDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AppointmentServiceResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/AppointmentService");
        });

        Configure<AbpExceptionLocalizationOptions>(options =>
        {
            options.MapCodeNamespace("AppointmentService", typeof(AppointmentServiceResource));
        });
    }
}
