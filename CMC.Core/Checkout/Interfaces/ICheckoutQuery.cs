using CMC.Core.Products.Models;

namespace CMC.Core.Products.Interfaces
{
    public interface ICheckoutQuery
    {
        Task<CheckoutResponse> Checkout(CheckoutRequest request);
    }
}
