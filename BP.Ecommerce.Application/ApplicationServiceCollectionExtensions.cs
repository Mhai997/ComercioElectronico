using BP.Ecommerce.Application.ServicesImplementations;
using BP.Ecommerce.Application.ServicesInterfaces;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BP.Ecommerce.Application
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
