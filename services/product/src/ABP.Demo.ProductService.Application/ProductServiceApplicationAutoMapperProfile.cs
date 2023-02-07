using AutoMapper;
using ABP.Demo.ProductService.Products;

namespace ABP.Demo.ProductService;

public class ProductServiceApplicationAutoMapperProfile : Profile
{
    public ProductServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>();
    }
}
