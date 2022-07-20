using AutoMapper;
using Curso.ComercioElectronico.Aplication.DTOs;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Application.ServicesInterfaces;
using Curso.ComercioElectronico.Domain.Entities;
using Curso.ComercioElectronico.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Application.ServicesImplementations
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository repository;
        private readonly IMapper mapper;

        public BrandService(IBrandRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var consulta = repository.GetAllBrands();
            consulta = consulta.Where(c => c.Id == id);
            var brand = consulta.SingleOrDefault();

            await repository.DeleteByIdAsync(brand);
            return true;
        }
        public async Task<ICollection<BrandDto>> GetAllBrandsAsync()
        {
            var query = repository.GetAllBrands();
            var listBrands = await query.Select(x => new BrandDto
            {
                Id = x.Id,
                Name = x.Name,
                

            }).ToListAsync();
            return listBrands;

        }
        public async Task<List<BrandDto>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            var query = await repository.GetQueryable(search, limit, offset, sort, order);
            return await query.Select(p => new BrandDto
            {
                Id = p.Id,
                Name = p.Name,
               
            }).ToListAsync();
        }

        public async Task<BrandDto> GetByIdAsync(Guid id)
        {
            var query = await repository.GetQueryableByIdAsync(id);
            return await query.Select(p => new BrandDto
            {
                Id = p.Id,
                Name = p.Name,
                
            }).SingleOrDefaultAsync();
        }

        public async Task<BrandDto> PostAsync(CreateBrandDto createBrandDto)
        {
            var query = await repository.PostAsync(mapper.Map<Brand>(createBrandDto));
            return await query.Select(p => new BrandDto
            {
                Id = p.Id,
                Name = p.Name,
                
            }).SingleOrDefaultAsync();
        }

        public async Task<bool> PutAsync(Guid id, CreateBrandDto brandDto)
        {
            var consulta = repository.GetAllBrands();
            consulta = consulta.Where(c => c.Id == id);
            var brand = consulta.SingleOrDefault();
           

            await repository.PutAsync(brand);            
            return true;
        }

        
    }
}
