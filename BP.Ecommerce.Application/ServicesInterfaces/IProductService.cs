using BP.Ecommerce.Application.Dtos;

namespace BP.Ecommerce.Application.ServicesInterfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync(string search, int limit, int offset, string sort, string order);
        Task<ProductDto> GetByIdAsync(Guid id);
        Task<ProductDto> PostAsync(CreateProductDto createProductDto);
        Task<bool> PutAsync(Guid id, CreateProductDto createProductDto);
        Task<bool> DeleteByIdAsync(Guid id);

        Task<ICollection<ProductDto>> GetAllProductsAsync();
    }
}
