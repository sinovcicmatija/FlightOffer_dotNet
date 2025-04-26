using System.Text.Json.Serialization;

namespace FlightSearch.Models.External.SubModel
{
    public class CabinRestrictions
    {
        [JsonPropertyName("cabin")]
        public string? Cabin { get; set; }

        [JsonPropertyName("coverage")]
        public string? Coverage { get; set; }

        [JsonPropertyName("originDestinationIds")]
        public List<string>? OriginDestinationIds { get; set; }
    }
}
