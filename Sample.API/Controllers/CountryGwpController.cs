using Microsoft.AspNetCore.Mvc;
using Sample.API.Models;
using Sample.API.Service;


namespace Sample.API.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    [Route("server")]
    public class CountryGwpController : ControllerBase
    {
        private readonly IBusinessComponent _businessComponent;
        private readonly ILogger<CountryGwpController> _logger;

        public CountryGwpController(ILogger<CountryGwpController> logger, IBusinessComponent businessComponent)
        {
            _businessComponent = businessComponent;
            _logger = logger;

        }
        

        [Route("gwp/avg")]
        [HttpPost]
        public async Task<ActionResult> Avg([FromBody] InputParam input)
        {
            try
            {
                if (!string.IsNullOrEmpty(input.Country))
                {
                    var response = await _businessComponent.GetAvgGwpAsync(input);
                    _logger.LogInformation("Data retrieved successfully");
                    return Ok(response);
                }
                else
                {
                    return BadRequest("Please provide Country name");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Some thing went wrong, please contact helpdesk.");
            }
            
        }

    }
}
