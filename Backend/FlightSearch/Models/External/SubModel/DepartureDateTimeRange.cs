using System.Text.Json.Serialization;

namespace FlightSearch.Models.External.SubModel
{
    public class DepartureDateTimeRange
    {
        [JsonPropertyName("date")]
        public string? Date { get; set; }

        [JsonPropertyName("time")]
        public string? Time { get; set; }
    }
}
