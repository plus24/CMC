using CMC.Core.Checkout.Models;
using CMC.Infrastructure.Entities;

namespace CMC.Core.Common
{
    public interface ICurrencyRateService
    {
        Task<IEnumerable<Product>> getProductInCurrency(string currency, IEnumerable<Product> products);
        Task<IEnumerable<ProductItem>> getProductItemInCurrency(string currency, IEnumerable<ProductItem> productItems);
        Task<double> ConvertRate(string currency, double amount);
    }
}
