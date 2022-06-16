using AutoMapper;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace TopShopServer.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Models.Product, DTOs.ProductDto>();
                //.ForMember(x => x.Photo, o => { o.MapFrom(jo => JsonSerializer.Deserialize<IEnumerable<string>>(jo.Photo)); });
        }
    }
}
