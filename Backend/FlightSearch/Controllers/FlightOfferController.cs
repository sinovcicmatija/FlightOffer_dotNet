using FlightSearch.Interfaces;
using FlightSearch.Models.DTOs;
using FlightSearch.Models.External;
using FlightSearch.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlightSearch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightOfferController : ControllerBase
    {
        private readonly IFlightOfferService _flightOfferService;

        public FlightOfferController(IFlightOfferService flightOfferService)
        {
            _flightOfferService = flightOfferService;
        }

        [HttpPost]
        [Route("flight-offers")]

        public async Task<IActionResult> GetFlightOffer([FromBody] FlightOfferCallDTO callModelDTO)
        {
            var flightOfferData = await _flightOfferService.GetFlightOffer(callModelDTO);
            return Ok(flightOfferData);
        }
    }
}
