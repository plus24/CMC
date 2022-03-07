using CMC.Infrastructure.Contexts;
using CMC.Infrastructure.Entities;
using CMC.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMC.Infrastructure.Services
{
    public class ProductService: IProductService
    {
        private readonly InMemoryContext _dbContext;
        public ProductService(InMemoryContext dbContext)
        {
            _dbContext = dbContext;

            // this is a hack to seed data into the in memory database. Do not use this in production.
            _dbContext.Database.EnsureCreated();
        }
        public async Task<IEnumerable<Product>> GetPaginatedAsync(int page, int count)
        {
            IEnumerable<Product> products = await _dbContext.Products.Skip((page - 1) * count)
                                         .Take(count).ToListAsync();

            return products;
        }

        public async Task<Product> GetProductByID(int id)
        {
            IEnumerable<Product> products = await _dbContext.Products.Where(product=>product.Id==id).ToListAsync();

            return products.FirstOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProductsByIDs(List<int> ids)
        {
            IEnumerable<Product> products = await _dbContext.Products.Where(product => ids.Contains(product.Id)).ToListAsync();

            return products;
        }
    }
}
