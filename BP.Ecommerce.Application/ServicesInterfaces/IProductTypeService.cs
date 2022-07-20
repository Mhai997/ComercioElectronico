using Curso.ComercioElectronico.Aplication.DTOs;
using Curso.ComercioElectronico.Application.Dtos;

namespace Curso.ComercioElectronico.Application.ServicesInterfaces
{
    public interface IProductTypeService
    {
        Task<List<ProductTypeDto>> GetAllAsync(string search, int limit, int offset, string sort, string order);
        Task<ProductTypeDto> GetByIdAsync(Guid id);
        Task<ProductTypeDto> PostAsync(CreateProductTypeDto createProductTypeDto);
        Task<bool> PutAsync(Guid id, CreateProductTypeDto createProductTypeDto);
        Task<bool> DeleteByIdAsync(Guid id);

        Task<ICollection<ProductTypeDto>> GetAllProductTypesAsync();
    }
}
