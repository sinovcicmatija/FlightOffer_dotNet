using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class DepartureArrival
    {
        [JsonPropertyName("iataCode")]
        public string? IataCode { get; set; }

        [JsonPropertyName("at")]
        public string? At { get; set; }
    }
}
