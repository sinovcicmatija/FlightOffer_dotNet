using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class LocationInfo
    {
        [JsonPropertyName("cityCode")]
        public string? CityCode { get; set; }

        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }
    }
}
