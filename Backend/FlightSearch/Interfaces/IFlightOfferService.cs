using FlightSearch.Models.DTOs;

namespace FlightSearch.Interfaces
{
    public interface IFlightOfferService
    {
        Task<List<FlightOfferDTO>> GetFlightOffer();
    }
}
