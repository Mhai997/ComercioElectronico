using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Domain.RepositoriesInterfaces
{
    public interface IGenericRepository<T>
    {
        IQueryable<T> GetAllAsync();
        Task<IQueryable<T>> GetQueryable(string search, int limit, int offset, string sort, string order);
        Task<IQueryable<T>> GetQueryableByIdAsync(Guid id);
        Task<IQueryable<T>> PostAsync(T T);
        Task PutAsync(T T);
        Task DeleteByIdAsync(T T);
    }
}
