using Curso.ComercioElectronico.Domain.Entities;

namespace Curso.ComercioElectronico.Domain.RepositoryInterfaces
{
    public interface IBrandRepository
    {
        IQueryable<Brand> GetAllBrands();
        Task<IQueryable<Brand>> GetQueryable(string search, int limit, int offset, string sort, string order);
        Task<IQueryable<Brand>> GetQueryableByIdAsync(Guid id);
        Task<IQueryable<Brand>> PostAsync(Brand brand);
        Task PutAsync(Brand brand);
        Task DeleteByIdAsync(Brand brand);
    }
}
