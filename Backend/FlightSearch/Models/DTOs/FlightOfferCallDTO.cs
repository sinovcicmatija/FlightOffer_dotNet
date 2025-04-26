using System.Text.Json.Serialization;

namespace FlightSearch.Models.DTOs
{
    public class FlightOfferCallDTO
    {
        [JsonPropertyName("originIata")]
        public string OriginIata { get; set; } = string.Empty;

        [JsonPropertyName("destinationIata")]
        public string DestinationIata { get; set; } = string.Empty;

        [JsonPropertyName("departureDate")]
        public string DepartureDate { get; set; } = string.Empty;

        [JsonPropertyName("returnDate")]
        public string? ReturnDate { get; set; }

        [JsonPropertyName("isRoundTrip")]
        public bool IsRoundTrip { get; set; }

        [JsonPropertyName("adults")]
        public int Adults { get; set; }

        [JsonPropertyName("children")]
        public int? Children { get; set; }

        [JsonPropertyName("cabinClass")]
        public string CabinClass { get; set; } = string.Empty;

        [JsonPropertyName("currency")]
        public string Currency { get; set; } = string.Empty;
    }
}
