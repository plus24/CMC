using AutoMapper;
using CMC.Core.Checkout.Models;
using CMC.Core.Common;
using CMC.Core.Products.Interfaces;
using CMC.Core.Products.Models;
using CMC.Infrastructure.Entities;
using CMC.Infrastructure.Interfaces;

namespace CMC.Core.Products.Queries
{
    public class CheckoutQuery : ICheckoutQuery
    {
        private readonly IProductService _productService;
        private readonly IShippingCostsService _shippingCostsService;
        private readonly ICurrencyRateService _currencyRateService;

        public CheckoutQuery(IProductService productService, IShippingCostsService shippingCostsService, ICurrencyRateService currencyRateService)
        {
            _productService = productService;
            _shippingCostsService = shippingCostsService;
            _currencyRateService = currencyRateService;
        }

        public async Task<CheckoutResponse> Checkout(CheckoutRequest request)
        {
            IEnumerable<Product> products = await _productService.GetProductsByIDs(request.Products.Select(x => x.Id).ToList());
            IEnumerable<ProductItem> productItems = MapProductItem(products, request.Products);
            var totalProductsCost = productItems.Sum(prod => prod.Total);
            var checkoutResponse = new CheckoutResponse()
            {
                Products = (await _currencyRateService.getProductItemInCurrency(request.Currency, productItems)).ToList(),
                ShippingCost = await _currencyRateService.ConvertRate(request.Currency, await _shippingCostsService.GetShippingCost(totalProductsCost))
            };
            checkoutResponse.Total = checkoutResponse.ShippingCost + await _currencyRateService.ConvertRate(request.Currency, totalProductsCost);
            return checkoutResponse;
        }

        private IEnumerable<ProductItem> MapProductItem(IEnumerable<Product> products, IEnumerable<ProductItem> productItems)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Product, ProductItem>()
            //.ForMember(dest => dest.Quantity, act => act.Ignore())
            );
            var mapper = new Mapper(config);
            var filledProductItems = mapper.Map<List<ProductItem>>(products);
            foreach (var filledProductItem in filledProductItems)
            {
                var productItem = productItems.FirstOrDefault(x => x.Id == filledProductItem.Id);
                filledProductItem.Quantity = productItem.Quantity;
                filledProductItem.Total = productItem.Quantity * filledProductItem.Price;
            }
            return filledProductItems;
        }
    }
}
