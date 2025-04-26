using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class Dictionaries
    {
            [JsonPropertyName("locations")]
            public Dictionary<string, LocationInfo>? Locations { get; set; }

            [JsonPropertyName("aircraft")]
            public Dictionary<string, string>? Aircraft { get; set; }

            [JsonPropertyName("carriers")]
            public Dictionary<string, string>? Carriers { get; set; }
        }
}
