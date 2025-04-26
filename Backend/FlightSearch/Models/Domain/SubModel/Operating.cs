using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class Operating
    {
        [JsonPropertyName("carrierCode")]
        public string? CarrierCode { get; set; }
    }
}

