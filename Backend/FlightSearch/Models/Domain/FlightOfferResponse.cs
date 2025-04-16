using FlightSearch.Models.Domain.SubModel;
using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain
{
    public class FlightOfferResponse
    {

        [JsonPropertyName("meta")]
        public Meta? Meta { get; set; }

        [JsonPropertyName("data")]
        public FlightData[]? Data { get; set; }

        [JsonPropertyName("dictionaries")]
        public Dictionaries? Dictionaries { get; set; }
    }
}
