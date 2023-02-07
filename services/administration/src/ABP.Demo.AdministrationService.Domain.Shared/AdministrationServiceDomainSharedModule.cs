using ABP.Demo.AdministrationService.Localization;
using ABP.Demo.IdentityService;
using Volo.Abp.AuditLogging;
using Volo.Abp.FeatureManagement;
using Volo.Abp.LanguageManagement;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TextTemplateManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ABP.Demo.AdministrationService;

[DependsOn(
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpFeatureManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule),
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(LanguageManagementDomainSharedModule),
    typeof(TextTemplateManagementDomainSharedModule)
)]
public class AdministrationServiceDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AdministrationServiceModuleExtensionConfigurator.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AdministrationServiceDomainSharedModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<AdministrationServiceResource>("en")
                .AddBaseTypes(typeof(AbpValidationResource))
                .AddVirtualJson("/Localization/AdministrationService");
        });

    }
}
