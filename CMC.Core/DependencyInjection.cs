using CMC.Core.Common;
using CMC.Core.Products.Interfaces;
using CMC.Core.Products.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace CMC.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IListProductsQuery, ListProductsQuery>();

            services.AddScoped<ICheckoutQuery, CheckoutQuery>();

            services.AddScoped<ICurrencyRateService, CurrencyRateService>();

            return services;
        }
    }
}
