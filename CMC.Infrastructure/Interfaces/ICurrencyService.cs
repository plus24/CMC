using CMC.Infrastructure.Entities;

namespace CMC.Infrastructure.Interfaces
{
    public interface ICurrencyService
    {
        Task<double> GetCurrencyRate(string source, string target);
    }
}
