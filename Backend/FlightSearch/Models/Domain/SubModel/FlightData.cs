using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class FlightData
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("id")]
        public string? Id { get; set; }

        [JsonPropertyName("source")]
        public string? Source { get; set; }

        [JsonPropertyName("instantTicketingRequired")]
        public bool InstantTicketingRequired { get; set; }

        [JsonPropertyName("nonHomogeneous")]
        public bool NonHomogeneous { get; set; }

        [JsonPropertyName("oneWay")]
        public bool OneWay { get; set; }

        [JsonPropertyName("lastTicketingDate")]
        public string? LastTicketingDate { get; set; }

        [JsonPropertyName("numberOfBookableSeats")]
        public int NumberOfBookableSeats { get; set; }

        [JsonPropertyName("itineraries")]
        public Itineraries[]? Itineraries { get; set; }

        [JsonPropertyName("price")]
        public Price? Price { get; set; }

        [JsonPropertyName("pricingOptions")]
        public PricingOptions? PricingOptions { get; set; }

        [JsonPropertyName("validatingAirlineCodes")]
        public string[]? ValidatingAirlineCodes { get; set; }

        [JsonPropertyName("travelerPricings")]
        public TravelerPricing[]? TravelerPricings { get; set; }
    }
}
