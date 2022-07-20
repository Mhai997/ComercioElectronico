using Curso.ComercioElectronico.Application.ServicesImplementations;
using Curso.ComercioElectronico.Application.ServicesInterfaces;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Curso.ComercioElectronico.Application
{
    public static class ApplicationServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
         
        
            services.AddScoped<IProductService, ProductService>();
           

            return services;
        }
    }
}
