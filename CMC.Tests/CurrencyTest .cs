using CMC.Core.Common;
using CMC.Core.Products.Interfaces;
using CMC.Core.Products.Queries;
using CMC.Infrastructure.Contexts;
using CMC.Infrastructure.Entities;
using CMC.Infrastructure.Interfaces;
using CMC.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CMC.Tests
{
    public class CurrencyTest
    {
        private IProductService _productService;
        private ICurrencyService _currencyService;
        private ICurrencyRateService _currencyRateService;
        private IListProductsQuery _listProductsQuery;
        public CurrencyTest()
        {
            var dbContext = new InMemoryContext();
            if (_productService == null)
            {
                _productService = new ProductService(dbContext);
            }
            if (_currencyService == null)
            {
                _currencyService = new CurrencyService(dbContext);
            }
            if (_currencyRateService == null)
            {
                _currencyRateService = new CurrencyRateService(_currencyService);
            }
            if (_listProductsQuery == null)
            {
                _listProductsQuery = new ListProductsQuery(_productService, _currencyRateService);
            }
        }


        [Fact]
        public async void GetCurrencyRates_AUD_TO_USD()
        {
            //Act
            var rate = await _currencyService.GetCurrencyRate("AUD", "USD");

            //Assert
            Assert.True(rate > 0, "Expected rate to be greater than 0.");
        }

        [Fact]
        public async void ConvertCurrencyRates_AUD_TO_USD()
        {
            // Act
            var rate = await _currencyRateService.ConvertRate("USD", 10);

            // Assert
            Assert.True(rate > 0, "Expected rate to be greater than 0.");
        }

        [Fact]
        public async Task Convert_Product_Price()
        {
            // Arrange
            var currencyRates = new List<CurrencyRate>();
            var dbContext = new Mock<InMemoryContext>();
            var currencyService = new Mock<CurrencyService>(dbContext.Object);
            currencyService.Setup(x => x.GetCurrencyRate("AUD", "USD")).Returns(Task.FromResult(4.0));
            _currencyRateService = new CurrencyRateService(currencyService.Object);

            var products = new List<Product>();
            products.Add(new Product() { Id = 1, Price = 10 });
            products.Add(new Product() { Id = 2, Price = 20 });

            // Act
            var productsInCurrency = await _currencyRateService.getProductInCurrency("USD", products.AsEnumerable());

            // Assert
            Assert.True(productsInCurrency.FirstOrDefault(x => x.Id == 1).Price == 40, "Expected to converted price to mocked value (10 x 4).");
            Assert.True(productsInCurrency.FirstOrDefault(x => x.Id == 2).Price == 80, "Expected to converted price to mocked value (20 x 4).");
        }
    }
}
