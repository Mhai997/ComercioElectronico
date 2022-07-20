using AutoMapper;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Application.ServicesInterfaces;
using Curso.ComercioElectronico.Domain.Entities;
using Curso.ComercioElectronico.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Application.ServicesImplementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository repository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var consulta = repository.GetAllProducts();
            consulta = consulta.Where(c => c.Id == id);
            var product = consulta.SingleOrDefault();

            await repository.DeleteByIdAsync(product);
            return true;
        }
        public async Task<ICollection<ProductDto>> GetAllProductsAsync()
        {
            var query = repository.GetAllProducts();
            var listProducts = await query.Select(x => new ProductDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Stock = x.Stock,
                BrandId = x.BrandId,
                ProductTypeId = x.ProductTypeId

            }).ToListAsync();
            return listProducts;

        }
        public async Task<List<ProductDto>> GetAllAsync(string search, int limit, int offset, string sort, string order)
        {
            var query = await repository.GetQueryable(search, limit, offset, sort, order);
            return await query.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Stock = p.Stock,
                Price = p.Price,
                BrandId = p.BrandId,
                ProductTypeId = p.ProductTypeId,
            }).ToListAsync();
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var query = await repository.GetQueryableByIdAsync(id);
            return await query.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Stock = p.Stock,
                Price = p.Price,
                BrandId = p.BrandId,
                ProductTypeId = p.ProductTypeId,
            }).SingleOrDefaultAsync();
        }

        public async Task<ProductDto> PostAsync(CreateProductDto createProductDto)
        {
            var query = await repository.PostAsync(mapper.Map<Product>(createProductDto));
            return await query.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Stock = p.Stock,
                Price = p.Price,
                BrandId = p.BrandId,
                ProductTypeId = p.ProductTypeId,
            }).SingleOrDefaultAsync();
        }

        public async Task<bool> PutAsync(Guid id, CreateProductDto productDto)
        {
            var consulta = repository.GetAllProducts();
            consulta = consulta.Where(c => c.Id == id);
            var product = consulta.SingleOrDefault();
            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Stock = productDto.Stock;
            product.BrandId = productDto.BrandId;
            product.ProductTypeId = productDto.ProductTypeId;

            await repository.PutAsync(product);            return true;
        }
    }
}
