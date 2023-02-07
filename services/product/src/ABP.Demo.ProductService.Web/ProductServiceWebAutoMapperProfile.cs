using AutoMapper;
using ABP.Demo.ProductService.Products;

namespace ABP.Demo.ProductService.Web;

public class ProductServiceWebAutoMapperProfile : Profile
{
    public ProductServiceWebAutoMapperProfile()
    {
        CreateMap<ProductDto, ProductUpdateDto>();
    }
}
