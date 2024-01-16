using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class Temperature
    {
        [JsonPropertyName("Minimum")]
        public Minimum Minimum { get; set; }

        [JsonPropertyName("Maximum")]
        public Maximum Maximum { get; set; }
    }
}
