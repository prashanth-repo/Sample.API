using Sample.API.Models;

namespace Sample.API.Service
{
    public interface IBusinessComponent
    {
        Task<GrossWrittenPremium> GetAvgGwpAsync(InputParam input);
    }
}