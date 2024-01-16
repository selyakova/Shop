using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class Maximum
    {
        [JsonPropertyName("Value")]
        public int Value { get; set; }

        [JsonPropertyName("Unit")]
        public string Unit { get; set; }

        [JsonPropertyName("UnitType")]
        public int UnitType { get; set; }
    }
}
