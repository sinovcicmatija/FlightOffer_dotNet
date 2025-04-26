using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class Aircraft
    {
        [JsonPropertyName("code")]
        public string? Code { get; set; }
    }
}
