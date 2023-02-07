using ABP.Demo.ProductService.Localization;
using Volo.Abp.Application.Services;

namespace ABP.Demo.ProductService;

public abstract class ProductServiceAppService : ApplicationService
{
    protected ProductServiceAppService()
    {
        LocalizationResource = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceApplicationModule);
    }
}
