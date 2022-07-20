using BP.Ecommerce.Domain.Entities;
using BP.Ecommerce.Domain.RepositoryInterfaces;
using BP.Ecommerce.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BP.Ecommerce.Infraestructure.RepositoriesImplementations
{
    public class ProductRepository : IProductRepository
    {
        private readonly ComercioElectronicoDbContext context;

        public ProductRepository(ComercioElectronicoDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteByIdAsync(Product product)
        {
            context.Remove(product);
            await context.SaveChangesAsync();
        }

        public async Task<IQueryable<Product>> GetQueryable(string search, int limit, int offset, string sort, string order)
        {
            
            var query = context.Products.Where(b => b.Status == true);

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

        public async Task<IQueryable<Product>> GetQueryableByIdAsync(Guid id)
        {
            var query = context.Products.Where(b => b.Id == id && b.Status == true);
            Product productExist = await query.SingleOrDefaultAsync();
            
            return query;
        }

        public async Task<IQueryable<Product>> PostAsync(Product product)
        {
            var query = context.Products.Where(b => b.Name == product.Name);
            

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return query;
        }
        public IQueryable<Product> GetAllProducts()
        {
            return context.Products.AsQueryable();
        }
        public async Task PutAsync(Product product)
        {
            context.Update(product);
            await context.SaveChangesAsync();
        }
    }
}
