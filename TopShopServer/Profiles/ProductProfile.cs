using AutoMapper;

namespace TopShopServer.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, DTOs.ProductDto>();
        }
    }
}
