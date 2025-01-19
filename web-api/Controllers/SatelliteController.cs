using Microsoft.AspNetCore.Mvc;
using web_api.Interfaces;


namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SatelliteController : ControllerBase
    {

        private readonly ISatelliteService _satelliteService;
        public SatelliteController(ISatelliteService satlliteService)
        {
            _satelliteService = satlliteService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSatelliteNamesAsync()
        {
            var apodData = await _satelliteService.GetSatelliteNamesAsync();
            return Ok(apodData);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetSatelliteNameAsync([FromRoute] string name)
        {
            var apodData = await _satelliteService.GetSatelliteByNameAsync(name);
            return Ok(apodData);
        }
    }
}
