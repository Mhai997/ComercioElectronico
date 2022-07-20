using BP.Ecommerce.Application.Dtos;
using BP.Ecommerce.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace BP.Ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService service;

        public ProductController(IProductService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetAllAsync(string? search = "", int limit = 5, int offset = 0, string sort = "Name", string order = "asc")
        {
            return await service.GetAllAsync(search, limit, offset, sort, order);
        }

        [HttpGet("{id}")]
        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ProductDto> PostAsync(CreateProductDto createProductDto)
        {
            return await service.PostAsync(createProductDto);
        }

        [HttpPut]
        public async Task<bool> PutAsync(Guid id, CreateProductDto productDto)
        {
            return await service.PutAsync(id, productDto);
        }

        [HttpDelete]
        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            return await service.DeleteByIdAsync(id);
        }
        [HttpGet("ObtenerTodos")]
        public async Task<ICollection<ProductDto>> GetAllProductsAsync()
        {
            return await service.GetAllProductsAsync();
        }
    }
}
