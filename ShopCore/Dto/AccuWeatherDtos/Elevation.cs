using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class Elevation
    {
        [JsonPropertyName("Metric")]
        public Metric Metric { get; set; }

        [JsonPropertyName("Imperial")]
        public Imperial Imperial { get; set; }
    }
}
