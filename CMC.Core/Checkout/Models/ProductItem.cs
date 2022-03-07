using CMC.Infrastructure.Entities;

namespace CMC.Core.Checkout.Models
{
    public class ProductItem : Product
    {
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}
