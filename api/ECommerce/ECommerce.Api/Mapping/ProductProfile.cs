using AutoMapper;
using ECommerce.Api.Domain;
using ECommerce.Api.Models;

namespace ECommerce.Api.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>();
        }
    }
}
