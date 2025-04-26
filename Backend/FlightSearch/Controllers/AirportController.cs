using FlightSearch.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlightSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;

        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        [HttpGet]
        [Route("airports")]

        public async Task<IActionResult> GetAirport([FromQuery] string keyword)
        {
            var airportData = await _airportService.GetAirport(keyword);
            return Ok(airportData);
        }
        
    }
}
