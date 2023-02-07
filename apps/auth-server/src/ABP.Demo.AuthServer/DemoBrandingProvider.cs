using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace ABP.Demo.AuthServer;

[Dependency(ReplaceServices = true)]
public class DemoBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Demo";
}
