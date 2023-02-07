using ABP.Demo.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace ABP.Demo;

[DependsOn(
    typeof(AbpValidationModule)
    )]
public class DemoSharedLocalizationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<DemoSharedLocalizationModule>();
        });

        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Add<DemoResource>("en")
                .AddBaseTypes(
                    typeof(AbpValidationResource)
                ).AddVirtualJson("/Localization/Demo");

            options.DefaultResourceType = typeof(DemoResource);
        });
    }
}
