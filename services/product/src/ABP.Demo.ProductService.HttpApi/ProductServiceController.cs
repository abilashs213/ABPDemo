using ABP.Demo.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace ABP.Demo.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
