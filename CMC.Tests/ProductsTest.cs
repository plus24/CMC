using CMC.Core.Common;
using CMC.Core.Products.Interfaces;
using CMC.Core.Products.Queries;
using CMC.Infrastructure.Contexts;
using CMC.Infrastructure.Interfaces;
using CMC.Infrastructure.Services;
using System.Linq;
using Xunit;

namespace CMC.Tests
{
    public class ProductsTest
    {
        private IProductService _productService;
        private ICurrencyService _currencyService;
        private ICurrencyRateService _currencyRateService;
        private IListProductsQuery _listProductsQuery;
        public ProductsTest()
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
        public async void GetProducts_P1_10()
        {
            //Act
            var products = await _listProductsQuery.GetProducts(1, 10, "AUD");

            //Assert
            Assert.Equal(products.Count(), 10);
        }


        [Fact]
        public async void GetProducts_P1_5()
        {
            //Act
            var products = await _listProductsQuery.GetProducts(1, 5, "AUD");

            //Assert
            Assert.Equal(products.Count(), 5);
        }
    }
}
