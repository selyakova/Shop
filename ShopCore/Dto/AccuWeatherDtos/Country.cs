using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class Country
    {
        [JsonPropertyName("ID")]
        public string ID { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("EnglishName")]
        public string EnglishName { get; set; }
    }
}
