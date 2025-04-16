using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class Itineraries
    {
        [JsonPropertyName("duration")]
        public string? Duration { get; set; }

        [JsonPropertyName("segments")]
        public Segments[]? Segments { get; set; }
    }
}
