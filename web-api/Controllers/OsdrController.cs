using Microsoft.AspNetCore.Mvc;
using web_api.Interfaces;
//3.W ramach zbioru Open Science Data Repository Public API nalezy dodać kontroler /api/osdr
//posiadający:
//-metoda GetVehicles pobierająca wszystkie dostępne pojazdy
//- metodę GetVehicle dla której przekazujemy url pod którym dostępne są informacje o pojeździe
//- metodę GetMissionDetails dla której przekazujemy url pod którym dostępne są informacje o misji
namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OsdrController : ControllerBase
    {
        private readonly IOsdrService _osdrService;
        private readonly IConfiguration _configuration;

        public OsdrController(IOsdrService osdrService, IConfiguration configuration)
        {
            _osdrService = osdrService;
            _configuration = configuration;
        }


        [HttpGet("vehicles")]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _osdrService.GetVehiclesAsync();
            return Ok(vehicles);
        }

        [HttpGet("vehicle")]
        public async Task<IActionResult> GetVehicle([FromQuery] string url)
        {

            var vehicle = await _osdrService.GetVehicleByUrlAsync(url);
            return Ok(vehicle);

        }

        [HttpGet("mission-details")]
        public async Task<IActionResult> GetMissionDetails([FromQuery] string url)
        {

            var missionDetails = await _osdrService.GetMissionByUrlAsync(url);
            return Ok(missionDetails);

        }
    }
}
