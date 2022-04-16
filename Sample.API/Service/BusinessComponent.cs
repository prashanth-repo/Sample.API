using Sample.API.Models;

namespace Sample.API.Service
{
    public class BusinessComponent :IBusinessComponent
    {
        public async Task<GrossWrittenPremium> GetAvgGwpAsync(InputParam input)
        {
            GrossWrittenPremium avgGwp = new GrossWrittenPremium();
            await Task.Run(() =>
            {
                avgGwp.Transport = "446001906.1";
                avgGwp.liability = "634545022.9";
            });

            return avgGwp;
        }

        
    }
}
