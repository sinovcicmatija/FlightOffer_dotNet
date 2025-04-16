using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class TravelerPricing
    {
        [JsonPropertyName("travelerId")]
        public string? TravelerId { get; set; }

        [JsonPropertyName("fareOption")]
        public string? FareOption { get; set; }

        [JsonPropertyName("travelerType")]
        public string? TravelerType { get; set; }

        [JsonPropertyName("price")]
        public Price? Price { get; set; }

        [JsonPropertyName("fareDetailsBySegments")]
        public FareDetailsBySegment[]? FareDetailsBySegments { get; set; }
    }
}
