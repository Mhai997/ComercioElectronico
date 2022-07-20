
using Curso.ComercioElectronico.Domain.RepositoryInterfaces;
using Curso.ComercioElectronico.Infraestructure.RepositoriesImplementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Curso.ComercioElectronico.Infraestructure
{
    public static class InfraestructureServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
          
            services.AddTransient<IProductRepository, ProductRepository>();
          
            return services;
        }
    }
}
