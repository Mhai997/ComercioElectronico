using AutoMapper;
using Curso.ComercioElectronico.Aplication.DTOs;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Application.ServicesInterfaces;
using Curso.ComercioElectronico.Domain.Entities;
using Curso.ComercioElectronico.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Application.ServicesImplementations
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository repository;
        private readonly IMapper mapper;

        public ProductTypeService(IProductTypeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var consulta = repository.GetAllProductTypes();
            consulta = consulta.Where(c => c.Id == id);
            var productType = consulta.SingleOrDefault();

            await repository.DeleteByIdAsync(productType);
            return true;
        }
        public async Task<ICollection<ProductTypeDto>> GetAllProductTypesAsync()
        {
            var query = repository.GetAllProductTypes();
            var listProductTypes = await query.Select(x => new ProductTypeDto
            {
                Id = x.Id,
                Name = x.Name,
                

            }).ToListAsync();
            return listProductTypes;

        }
        public async Task<List<ProductTypeDto>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            var query = await repository.GetQueryable(search, limit, offset, sort, order);
            return await query.Select(p => new ProductTypeDto
            {
                Id = p.Id,
                Name = p.Name,
               
            }).ToListAsync();
        }

        public async Task<ProductTypeDto> GetByIdAsync(Guid id)
        {
            var query = await repository.GetQueryableByIdAsync(id);
            return await query.Select(p => new ProductTypeDto
            {
                Id = p.Id,
                Name = p.Name,
              
            }).SingleOrDefaultAsync();
        }

        public async Task<ProductTypeDto> PostAsync(CreateProductTypeDto createProductTypeDto)
        {
            var query = await repository.PostAsync(mapper.Map<ProductType>(createProductTypeDto));
            return await query.Select(p => new ProductTypeDto
            {
                Id = p.Id,
                Name = p.Name,
                
            }).SingleOrDefaultAsync();
        }

        public async Task<bool> PutAsync(Guid id, CreateProductTypeDto productTypeDto)
        {
            var consulta = repository.GetAllProductTypes();
            consulta = consulta.Where(c => c.Id == id);
            var productType = consulta.SingleOrDefault();
            productType.Name = productTypeDto.Name;
           

            await repository.PutAsync(productType);            
            return true;
        }
    }
}
