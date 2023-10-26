using Domain.Endpoint.Interfaces.Repositories;
using Infrastructure.Endpoint.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Endpoint.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            services.AddSingleton<IProveedorRepository, ProveedorRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IClienteRepository, ClienteRepository>();
            services.AddSingleton<ICatProductoRepository, CatProductoRepository>();
            services.AddSingleton<IProductoRepository, ProductoRepository>();

            return services;
        }
    }
}
