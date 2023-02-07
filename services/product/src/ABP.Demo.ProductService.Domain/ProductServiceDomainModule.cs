using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace ABP.Demo.ProductService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(ProductServiceDomainSharedModule)
)]
public class ProductServiceDomainModule : AbpModule
{

}
