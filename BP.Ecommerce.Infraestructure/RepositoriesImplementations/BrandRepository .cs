using Curso.ComercioElectronico.Domain.Entities;
using Curso.ComercioElectronico.Domain.RepositoryInterfaces;
using Curso.ComercioElectronico.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Curso.ComercioElectronico.Infraestructure.RepositoriesImplementations
{
    public class BrandRepository : IBrandRepository
    {
        private readonly ComercioElectronicoDbContext context;

        public BrandRepository(ComercioElectronicoDbContext context)
        {
            this.context = context;
        }

        public async Task DeleteByIdAsync(Brand brand)
        {
            context.Remove(brand);
            await context.SaveChangesAsync();
        }

        public async Task<IQueryable<Brand>> GetQueryable(string search, int limit, int offset, string sort, string order)
        {

            var query = context.Brands.Where(b => b.Status == true);

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

        public async Task<IQueryable<Brand>> GetQueryableByIdAsync(Guid id)
        {
            var query = context.Brands.Where(b => b.Id == id && b.Status == true);
            Brand brandExist = await query.SingleOrDefaultAsync();
            
            return query;
        }

        public async Task<IQueryable<Brand>> PostAsync(Brand brand)
        {
            var query = context.Brands.Where(b => b.Name == brand.Name);
            

            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();
            return query;
        }
        public IQueryable<Brand> GetAllBrands()
        {
            return context.Brands.AsQueryable();
        }
        public async Task PutAsync(Brand brand)
        {
            context.Update(brand);
            await context.SaveChangesAsync();
        }
    }
}
