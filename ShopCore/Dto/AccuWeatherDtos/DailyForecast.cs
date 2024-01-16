using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class DailyForecast
    {
        [JsonPropertyName("Date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("EpochDate")]
        public int EpochDate { get; set; }

        [JsonPropertyName("Temperature")]
        public Temperature Temperature { get; set; }

        [JsonPropertyName("Day")]
        public Day Day { get; set; }

        [JsonPropertyName("Night")]
        public Night Night { get; set; }

        [JsonPropertyName("Sources")]
        public List<string> Sources { get; set; }

        [JsonPropertyName("MobileLink")]
        public string MobileLink { get; set; }

        [JsonPropertyName("Link")]
        public string Link { get; set; }
    }
}
