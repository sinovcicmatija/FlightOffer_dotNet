using FlightSearch.Models.Domain;
using FlightSearch.Models.DTOs;

namespace FlightSearch.Helpers
{
    public class AirportMapper
    {

        public static List<AirportDTO> toDTO(LocationResponse response)
        {
            return response.Data
                 .Select(location => new AirportDTO
                 {
                     CityName = location.Address?.CityName,
                     AirportName = location.Name,
                     IataCode = location.IataCode,
                     CountryCode = location.Address?.CountryCode
                 })
                 .ToList();
        }
    }
}
