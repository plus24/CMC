using CMC.Core.Checkout.Models;
using CMC.Infrastructure.Entities;

namespace CMC.Core.Products.Models
{
    public class CheckoutResponse
    {
        public List<ProductItem> Products { get; set; }
        public double ShippingCost { get; set; }
        public double Total { get; set; }
    }
}
