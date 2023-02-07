﻿using ABP.Demo.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace ABP.Demo.ProductService.Web.Pages;

/* Inherit your PageModel classes from this class. */
public abstract class ProductServicePageModel : AbpPageModel
{
    protected ProductServicePageModel()
    {
        LocalizationResourceType = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceWebModule);
    }
}
