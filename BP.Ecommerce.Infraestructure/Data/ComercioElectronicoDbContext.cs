using Curso.ComercioElectronico.Domain.Entities;
using Curso.ComercioElectronico.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Curso.ComercioElectronico.Infraestructure.Data
{
    public class ComercioElectronicoDbContext : DbContext
    {
        public ComercioElectronicoDbContext(DbContextOptions<ComercioElectronicoDbContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<CestaItem> CestaItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //var conexionLocaldb = @"Server=(localdb)\mssqllocaldb;Database=ComercioElectronicoActual;Trusted_Connection=True";

            //optionsBuilder.UseSqlServer(conexionLocaldb); 
        }
    }
}
