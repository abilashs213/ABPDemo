using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;

namespace ABP.Demo.IdentityService;

[DependsOn(
    typeof(AbpIdentityProDomainModule),
    typeof(AbpOpenIddictDomainModule),
    typeof(IdentityServiceDomainSharedModule)
)]
public class IdentityServiceDomainModule : AbpModule
{
}
