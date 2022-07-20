using Curso.ComercioElectronico.Aplication.DTOs;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        private readonly IProductTypeService service;

        public ProductTypeController(IProductTypeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<ProductTypeDto>> GetAllAsync(string? search = "", int limit = 5, int offset = 0, string sort = "Name", string order = "asc")
        {
            return await service.GetAllAsync(search, limit, offset, sort, order);
        }

        [HttpGet("{id}")]
        public async Task<ProductTypeDto> GetByIdAsync(Guid id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ProductTypeDto> PostAsync(CreateProductTypeDto createProductTypeDto)
        {
            return await service.PostAsync(createProductTypeDto);
        }

        [HttpPut]
        public async Task<bool> PutAsync(Guid id, CreateProductTypeDto productTypeDto)
        {
            return await service.PutAsync(id, productTypeDto);
        }

        [HttpDelete]
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await service.DeleteByIdAsync(id);
        }
        [HttpGet("ObtenerTodos")]
        public async Task<ICollection<ProductTypeDto>> GetAllProductTypesAsync()
        {
            return await service.GetAllProductTypesAsync();
        }
    }
}
