using CMC.Core.Checkout.Models;
using CMC.Infrastructure.Entities;
using CMC.Infrastructure.Interfaces;

namespace CMC.Core.Common
{

    public class CurrencyRateService : ICurrencyRateService
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyRateService(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        public async Task<double> ConvertRate(string currency, double amount)
        {
            if (currency != "AUD")
            {
                var rate = await _currencyService.GetCurrencyRate("AUD", currency);
                return amount * rate;
            }
            return amount;
        }

        public async Task<IEnumerable<Product>> getProductInCurrency(string currency, IEnumerable<Product> products)
        {
            if (currency != "AUD")
            {
                var rate = await _currencyService.GetCurrencyRate("AUD", currency);
                var updatedProducts = new List<Product>();
                foreach (var product in products)
                {
                    product.Price *= rate;
                    updatedProducts.Add(product);
                }
                return updatedProducts;
            }
            return products;
        }

        public async Task<IEnumerable<ProductItem>> getProductItemInCurrency(string currency, IEnumerable<ProductItem> productItems)
        {
            if (currency != "AUD")
            {
                var rate = await _currencyService.GetCurrencyRate("AUD", currency);
                var updatedProducts = new List<ProductItem>();
                foreach (var product in productItems)
                {
                    product.Price *= rate;
                    product.Total *= rate;
                    updatedProducts.Add(product);
                }
                return updatedProducts;
            }
            return productItems;
        }
    }
}
