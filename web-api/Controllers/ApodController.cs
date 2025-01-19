using System.Security.AccessControl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
//2.W ramach zbioru APOD należy dodać kontroler /api/apod posiadający
//- metodę pobierającą informację o zdjęciu dnia, w tym urla do zdjęcia
//- serwis aplikacyjny lub serwis domenowy pozyskujący odpowiednie dane z serwera {NASA APIs}


//https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY

//Query Parameters
//Parameter	Type	Default	Description
//date	YYYY-MM-DD	today	The date of the APOD image to retrieve
//start_date	YYYY-MM-DD	none	The start of a date range, when requesting date for a range of dates. Cannot be used with date.
//end_date	YYYY-MM-DD	today	The end of the date range, when used with start_date.
//count	int	none	If this is specified then count randomly chosen images will be returned. Cannot be used with date or start_date and end_date.
//thumbs	bool	False	Return the URL of video thumbnail. If an APOD is not a video, this parameter is ignored.
//api_key	string	DEMO_KEY	api.nasa.gov key for expanded usage

namespace web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApodController : ControllerBase
    {
        private readonly IApodService _apodService;

        public ApodController(IApodService apodService)
        {
            _apodService = apodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetApod([FromQuery] string date = null)
        {
            var apodData = await _apodService.GetApodDataAsync(date);
            return Ok(apodData);
        }
    }
}