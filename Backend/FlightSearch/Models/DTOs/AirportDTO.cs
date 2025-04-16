using System.Text.Json.Serialization;

namespace FlightSearch.Models.DTOs
{
    public class AirportDTO
    {
        public string? CityName { get; set; }

        public string? AirportName { get; set; }

        public string? IataCode { get; set; }

        public string? CountryCode { get; set; }
    }
}
