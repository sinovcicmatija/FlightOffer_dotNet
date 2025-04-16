using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class Meta
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
    }
}
