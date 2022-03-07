using CMC.Infrastructure.Entities;

namespace CMC.Infrastructure.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetPaginatedAsync(int page, int count);

        Task<Product> GetProductByID(int id);

        Task<IEnumerable<Product>> GetProductsByIDs(List<int> ids);
    }
}
