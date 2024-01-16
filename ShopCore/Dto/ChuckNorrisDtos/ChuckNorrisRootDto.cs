using System.Text.Json.Serialization;

namespace Shop.Core.Dto.ChuckNorrisDtos
{
    public class ChuckNorrisRootDto
    {
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        [JsonPropertyName("created_at")]
        public string Created_At { get; set; }

        [JsonPropertyName("icon_url")]
        public string Icon_Url { get; set; }

        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("updated_at")]
        public string Updated_At { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
