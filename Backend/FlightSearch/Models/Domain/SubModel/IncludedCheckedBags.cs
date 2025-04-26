using System.Text.Json.Serialization;

namespace FlightSearch.Models.Domain.SubModel
{
    public class IncludedCheckedBags
    {
        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }
    }
}
