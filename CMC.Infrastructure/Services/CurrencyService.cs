using CMC.Infrastructure.Contexts;
using CMC.Infrastructure.Entities;
using CMC.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CMC.Infrastructure.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly InMemoryContext _dbContext;
        public CurrencyService(InMemoryContext dbContext)
        {
            _dbContext = dbContext;

            // this is a hack to seed data into the in memory database. Do not use this in production.
            if (_dbContext.Database != null)
                _dbContext.Database.EnsureCreated();
        }

        public virtual async Task<double> GetCurrencyRate(string source, string target)
        {
            IEnumerable<CurrencyRate> currencyRates = await _dbContext.CurrencyRates.Where(currencyRate => currencyRate.SourceCurrency == source && currencyRate.TargetCurrency == target).ToListAsync();
            return currencyRates.Any() ? currencyRates.FirstOrDefault().Rate : 1;
        }
    }
}
