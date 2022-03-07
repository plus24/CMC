using CMC.Infrastructure.Contexts;
using CMC.Infrastructure.Entities;
using CMC.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMC.Infrastructure.Services
{
    public class ShippingCostsService : IShippingCostsService
    {
        private readonly InMemoryContext _dbContext;
        public ShippingCostsService(InMemoryContext dbContext)
        {
            _dbContext = dbContext;

            // this is a hack to seed data into the in memory database. Do not use this in production.
            _dbContext.Database.EnsureCreated();
        }

        public async Task<double> GetShippingCost(double totalProductsPrice)
        {
            IEnumerable<ShippingCost> shippingCosts = await _dbContext.ShippingCosts.Where(shippingCosts => shippingCosts.Threshold > totalProductsPrice).OrderBy(shippingCosts=> shippingCosts.Threshold).ToListAsync();
            return shippingCosts.Any() ? shippingCosts.FirstOrDefault().Price : 0;
        }
    }
}
