using AutoMapper;
using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.DTOs;
using BP.Ecommerce.Domain.Entities;

namespace BP.Ecommerce.API.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductDto, Product>();

           
            CreateMap<CreateProductDto, Product>();
           


        }
    }
}
