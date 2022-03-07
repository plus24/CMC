using CMC.Core.Checkout.Models;
using CMC.Infrastructure.Entities;

namespace CMC.Core.Products.Models
{
    public class CheckoutRequest
    {
        public List<ProductItem> Products { get; set; }
        public string Currency { get; set; }
    }
}
