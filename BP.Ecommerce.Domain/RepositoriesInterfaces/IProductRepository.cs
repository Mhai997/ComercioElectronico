using Curso.ComercioElectronico.Domain.Entities;

namespace Curso.ComercioElectronico.Domain.RepositoryInterfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> GetAllProducts();
        Task<IQueryable<Product>> GetQueryable(string search, int limit, int offset, string sort, string order);
        Task<IQueryable<Product>> GetQueryableByIdAsync(Guid id);
        Task<IQueryable<Product>> PostAsync(Product product);
        Task PutAsync(Product product);
        Task DeleteByIdAsync(Product product);
    }
}
