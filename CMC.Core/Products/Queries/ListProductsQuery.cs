using CMC.Core.Common;
using CMC.Core.Products.Interfaces;
using CMC.Infrastructure.Entities;
using CMC.Infrastructure.Interfaces;
using FluentValidation;

namespace CMC.Core.Products.Queries
{
    public class ListProductsQuery : IListProductsQuery
    {
        public int PageNumber { get; set; }
        public int ItemsPerPage { get; set; } = 10;

        private readonly IProductService _productService;
        private readonly ICurrencyRateService _currencyRateService;

        public ListProductsQuery(IProductService productService, ICurrencyRateService currencyRateService)
        {
            _productService = productService;
            _currencyRateService = currencyRateService;
        }

        public class Validator : AbstractValidator<ListProductsQuery>
        {
            public Validator()
            {
                RuleFor(x => x.PageNumber)
                    .GreaterThan(0);
            }
        }

        public async Task<IEnumerable<Product>> GetProducts(int page, int count, string currency)
        {
            IEnumerable<Product> products = await _productService.GetPaginatedAsync(page, count);
            return await _currencyRateService.getProductInCurrency(currency, products);
        }
    }
}
