using CMC.Infrastructure.Entities;

namespace CMC.Infrastructure.Interfaces
{
    public interface IShippingCostsService
    {
        Task<double> GetShippingCost(double totalProductsPrice);
    }
}
