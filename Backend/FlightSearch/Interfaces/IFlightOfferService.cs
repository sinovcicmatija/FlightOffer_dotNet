using FlightSearch.Models.DTOs;
using FlightSearch.Models.External;

namespace FlightSearch.Interfaces
{
    public interface IFlightOfferService
    {
        Task<List<FlightOfferDTO>> GetFlightOffer(FlightOfferCallModel callModel);
    }
}
