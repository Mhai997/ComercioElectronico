using Curso.ComercioElectronico.Domain.Entities;

namespace Curso.ComercioElectronico.Domain.RepositoryInterfaces
{
    public interface IProductTypeRepository
    {
        IQueryable<ProductType> GetAllProductTypes();
        Task<IQueryable<ProductType>> GetQueryable(string search, int limit, int offset, string sort, string order);
        Task<IQueryable<ProductType>> GetQueryableByIdAsync(Guid id);
        Task<IQueryable<ProductType>> PostAsync(ProductType productType);
        Task PutAsync(ProductType productType);
        Task DeleteByIdAsync(ProductType productType);
    }
}
