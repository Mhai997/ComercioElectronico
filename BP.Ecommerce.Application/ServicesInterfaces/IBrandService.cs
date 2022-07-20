using Curso.ComercioElectronico.Aplication.DTOs;
using Curso.ComercioElectronico.Application.Dtos;

namespace Curso.ComercioElectronico.Application.ServicesInterfaces
{
    public interface IBrandService
    {
        Task<List<BrandDto>> GetAllAsync(string search, int limit, int offset, string sort, string order);
        Task<BrandDto> GetByIdAsync(Guid id);
        Task<BrandDto> PostAsync(CreateBrandDto createBrandDto);
        Task<bool> PutAsync(Guid id, CreateBrandDto createBrandDto);
        Task<bool> DeleteByIdAsync(Guid id);

        Task<ICollection<BrandDto>> GetAllBrandsAsync();
    }
}
