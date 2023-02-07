using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace ABP.Demo.AppointmentService;

[DependsOn(
    typeof(AppointmentServiceApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AppointmentServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(typeof(AppointmentServiceApplicationContractsModule).Assembly,
            AppointmentServiceRemoteServiceConsts.RemoteServiceName);

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AppointmentServiceHttpApiClientModule>();
        });
    }
}
