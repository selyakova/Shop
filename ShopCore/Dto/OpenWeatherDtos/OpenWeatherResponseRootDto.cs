﻿using System.ComponentModel;
using System.Security.Principal;
using System.Text.Json.Serialization;

namespace Shop.Core.Dto.OpenWeatherDtos
{
    public class OpenWeatherResponseRootDto
    {
        [JsonPropertyName("coord")]
        public Coord Coord { get; set; }

        [JsonPropertyName("weather")]
        public List<Weather> Weather { get; set; }

        [JsonPropertyName("base")]
        public string @base { get; set; }

        [JsonPropertyName("main")]
        public Main Main { get; set; }

        [JsonPropertyName("visibility")]
        public int Visibility { get; set; }

        [JsonPropertyName("wind")]
        public Wind Wind { get; set; }

        [JsonPropertyName("rain")]
        public Rain Rain { get; set; }

        [JsonPropertyName("clouds")]
        public Clouds Clouds { get; set; }

        [JsonPropertyName("dt")]
        public int Dt { get; set; }

        [JsonPropertyName("sys")]
        public Sys Sys { get; set; }

        [JsonPropertyName("timezone")]
        public int Timezone { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("cod")]
        public int Cod { get; set; }
    }
}
