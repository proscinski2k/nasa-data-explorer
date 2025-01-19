using Microsoft.AspNetCore.Mvc;
using web_api.Interfaces;
using web_api.Models;
//4.Kontroler / api / system zawierający:
//-metodę zwracającą informację czy serwis WebAPI działa oraz czy dostępny jest też serwis {NASA
//APIs}
//-metodę zwracającą informację o wersji systemu WebAPI (przeczytanej z konfiguracji, appsettings,
//np. informacje o autorach projektu) wraz z datą
namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SystemController : ControllerBase
    {
        private readonly ISystemService _systemService;

        public SystemController(ISystemService systemService)
        {
            _systemService = systemService;
        }

        [HttpGet("status")]
        public async Task<ActionResult<SystemInfoResponse>> GetSystemStatus()
        {
            var status = await _systemService.CheckSystemAvailabilityAsync();
            return Ok(status);
        }

        [HttpGet("version")]
        public ActionResult<SystemVersionResponse> GetSystemVersion()
        {
            var version = _systemService.GetSystemVersion();
            return Ok(version);
        }
    }
}
