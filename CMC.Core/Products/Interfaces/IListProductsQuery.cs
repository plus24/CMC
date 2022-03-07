using CMC.Infrastructure.Entities;

namespace CMC.Core.Products.Interfaces
{
    public interface IListProductsQuery
    {
        Task<IEnumerable<Product>> GetProducts(int page, int count, string currency);
    }
}
