using System.Text.Json.Serialization;

namespace FlightSearch.Models.External.SubModel
{
    public class Travelers
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("travelerType")]
        public string? TravelerType { get; set; }
    }
}
