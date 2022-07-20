using Curso.ComercioElectronico.Domain.Entities;
using Curso.ComercioElectronico.Domain.RepositoryInterfaces;
using Curso.ComercioElectronico.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure.RepositoriesImplementations
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ComercioElectronicoDbContext context;

        public ProductTypeRepository(ComercioElectronicoDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteByIdAsync(ProductType productType)
        {
            context.Remove(productType);
            await context.SaveChangesAsync();
        }

        public async Task<IQueryable<ProductType>> GetQueryable(string search, int limit, int offset, string sort, string order)
        {

            var query = context.ProductTypes.Where(b => b.Status == true);

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
               
                default:
                    throw new ArgumentException($"Argumento: {sort} no valido");
            }

            //pagination
            query = query.Skip(offset).Take(limit);

            return query;
        }

        public async Task<IQueryable<ProductType>> GetQueryableByIdAsync(Guid id)
        {
            var query = context.ProductTypes.Where(b => b.Id == id && b.Status == true);
            ProductType productTypeExist = await query.SingleOrDefaultAsync();
            
            return query;
        }

        public async Task<IQueryable<ProductType>> PostAsync(ProductType productType)
        {
            var query = context.ProductTypes.Where(b => b.Name == productType.Name);
            

            await context.ProductTypes.AddAsync(productType);
            await context.SaveChangesAsync();
            return query;
        }
        public IQueryable<ProductType> GetAllProductTypes()
        {
            return context.ProductTypes.AsQueryable();
        }
        public async Task PutAsync(ProductType productType)
        {
            context.Update(productType);
            await context.SaveChangesAsync();
        }
    }
}
