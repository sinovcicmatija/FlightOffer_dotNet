using System.Text.Json.Serialization;

namespace FlightSearch.Models.External.SubModel
{
    public class OriginDestinations
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("originLocationCode")]
        public string? OriginLocationCode { get; set; }

        [JsonPropertyName("destinationLocationCode")]
        public string? DestinationLocationCode { get; set; }

        [JsonPropertyName("departureDateTimeRange")]
        public DepartureDateTimeRange? DepartureDateTimeRange { get; set; }
    }
}
