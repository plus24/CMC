using CMC.Infrastructure.Contexts;
using CMC.Infrastructure.Interfaces;
using CMC.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CMC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<InMemoryContext>();

            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<ICurrencyService, CurrencyService>();

            services.AddScoped<IShippingCostsService, ShippingCostsService>();

            return services;
        }
    }
}
