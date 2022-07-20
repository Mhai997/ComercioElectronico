using BP.Ecommerce.Domain.Entities;
using Curso.ComercioElectronico.Domain.RepositoriesInterfaces;
using Curso.ComercioElectronico.Infraestructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.ComercioElectronico.Infraestructure.RepositoriesImplementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : CatalogueEntity
    {
        private readonly ComercioElectronicoDbContext context;
        public GenericRepository(ComercioElectronicoDbContext context)
        {
        
            this.context = context;
        }

        public async Task DeleteByIdAsync(T item)
        {
            context.Remove(item);
            await context.SaveChangesAsync();
        }

        public IQueryable<T> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetQueryable(string search, int limit, int offset, string sort, string order)
        {
            var query = context.Set<T>().Where(t => t.Status == true);
            

            //Search
            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(b => b.Name.ToUpper().Contains(search.ToUpper()));
            }

            //Sort and Order
            switch (sort.ToUpper())
            {
                case "NAME":
                    query = order.ToUpper() == "ASC"
                        ? query.OrderBy(b => b.Name)
                        : order.ToUpper() == "DESC"
                            ? query.OrderByDescending(b => b.Name)
                            : throw new ArgumentException($"Argumento: {order} no valido");
                    break;
                case "PRICE":
                    query = order.ToUpper() == "ASC"
                        ? query.OrderBy(b => b.Price)
                        : order.ToUpper() == "DESC"
                            ? query.OrderByDescending(b => b.Price)
                            : throw new ArgumentException($"Argumento: {order} no valido");
                    break;
                default:
                    throw new ArgumentException($"Argumento: {sort} no valido");
            }

            //pagination
            query = query.Skip(offset).Take(limit);

            return query;
        }

        public Task<IQueryable<T>> GetQueryableByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> PostAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(T item)
        {
            throw new NotImplementedException();
        }
    }
}
