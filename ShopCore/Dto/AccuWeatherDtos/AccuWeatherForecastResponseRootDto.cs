using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class AccuWeatherForecastResponseRootDto
    {
        [JsonPropertyName("Headline")]
        public Headline Headline { get; set; }

        [JsonPropertyName("DailyForecasts")]
        public List<DailyForecast> DailyForecasts { get; set; }
    }
}
