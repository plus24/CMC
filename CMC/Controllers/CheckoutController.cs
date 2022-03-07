using CMC.Core.Products.Interfaces;
using CMC.Core.Products.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CMC.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ICheckoutQuery _checkoutQuery;

        public CheckoutController(ILogger<ProductsController> logger, ICheckoutQuery checkoutQuery)
        {
            _logger = logger;
            _checkoutQuery = checkoutQuery;
        }

        [EnableCors("AllowOrigin")]
        [HttpPost(Name = "Checkout")]
        public async Task<CheckoutResponse> Checkout([FromBody] CheckoutRequest request)
        {
            return await _checkoutQuery.Checkout(request);
        }



        [EnableCors("AllowOrigin")]
        [HttpPost("PlaceOrder")]
        public OkObjectResult PlaceOrder([FromBody] CheckoutRequest request)
        {
            return Ok(Guid.NewGuid());
        }
    }
}
