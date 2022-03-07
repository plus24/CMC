using CMC.Core.Products.Interfaces;
using CMC.Infrastructure.Entities;
using CMC.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CMC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IListProductsQuery _listProductsQuery;

        public ProductsController(ILogger<ProductsController> logger, IListProductsQuery listProductsQuery)
        {
            _logger = logger;
            _listProductsQuery = listProductsQuery;
        }

        [EnableCors("AllowOrigin")]
        [HttpGet(Name = "List")]
        public async Task<IEnumerable<Product>> List(int page = 1, int count = 10, string? currency = "AUD")
        {
            IEnumerable<Product> products = await _listProductsQuery.GetProducts(page, count, currency);
            return products;
        }
    }
}
