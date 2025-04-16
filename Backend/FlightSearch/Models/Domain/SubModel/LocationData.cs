using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class LocationData
    {
        [JsonPropertyName("subType")]
        public string? SubType { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("iataCode")]
        public string? IataCode { get; set; }

        [JsonPropertyName("address")]
        public Address? Address { get; set; }
    }
}
