using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class Address
    {
        [JsonPropertyName("cityName")]
        public string? CityName { get; set; }

        [JsonPropertyName("cityCode")]
        public string? CityCode { get; set; }

        [JsonPropertyName("countryName")]
        public string? CountryName { get; set; }

        [JsonPropertyName("countryCode")]
        public string? CountryCode { get; set; }

        [JsonPropertyName("regionCode")]
        public string? RegionCode { get; set; }

    }
}
