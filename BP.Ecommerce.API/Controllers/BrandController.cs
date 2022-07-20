using Curso.ComercioElectronico.Aplication.DTOs;
using Curso.ComercioElectronico.Application.Dtos;
using Curso.ComercioElectronico.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace Curso.ComercioElectronico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService service;

        public BrandController(IBrandService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<BrandDto>> GetAllAsync(string? search = "", int limit = 5, int offset = 0, string sort = "Name", string order = "asc")
        {
            return await service.GetAllAsync(search, limit, offset, sort, order);
        }

        [HttpGet("{id}")]
        public async Task<BrandDto> GetByIdAsync(Guid id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<BrandDto> PostAsync(CreateBrandDto createBrandDto)
        {
            return await service.PostAsync(createBrandDto);
        }

        [HttpPut]
        public async Task<bool> PutAsync(Guid id, CreateBrandDto brandDto)
        {
            return await service.PutAsync(id, brandDto);
        }

        [HttpDelete]
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await service.DeleteByIdAsync(id);
        }
        [HttpGet("ObtenerTodos")]
        public async Task<ICollection<BrandDto>> GetAllBrandsAsync()
        {
            return await service.GetAllBrandsAsync();
        }
    }
}
