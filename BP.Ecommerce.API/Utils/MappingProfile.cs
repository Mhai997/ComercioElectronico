using AutoMapper;
using Curso.ComercioElectronico.Application.Dtos;

using Curso.ComercioElectronico.Domain.Entities;

namespace Curso.ComercioElectronico.API.Utils
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
