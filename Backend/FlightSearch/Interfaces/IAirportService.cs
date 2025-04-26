using FlightSearch.Models.DTOs;

namespace FlightSearch.Interfaces
{
    public interface IAirportService
    {
        Task<List<AirportDTO>> GetAirport(string keyword);
    }
}
