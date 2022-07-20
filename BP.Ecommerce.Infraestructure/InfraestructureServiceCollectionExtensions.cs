﻿
using BP.Ecommerce.Domain.RepositoryInterfaces;
using BP.Ecommerce.Infraestructure.RepositoriesImplementations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BP.Ecommerce.Infraestructure
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
