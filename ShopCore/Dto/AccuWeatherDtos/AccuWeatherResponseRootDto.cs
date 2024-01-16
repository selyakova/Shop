using System.Text.Json.Serialization;

namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class AccuWeatherResponseRootDto
    {
        [JsonPropertyName("Version")]
        public int Version { get; set; }

        [JsonPropertyName("Key")]
        public string Key { get; set; }

        [JsonPropertyName("Type")]
        public string Type { get; set; }

        [JsonPropertyName("Rank")]
        public int Rank { get; set; }

        [JsonPropertyName("LocalizedName")]
        public string LocalizedName { get; set; }

        [JsonPropertyName("EnglishName")]
        public string EnglishName { get; set; }

        [JsonPropertyName("PrimaryPostalCode")]
        public string PrimaryPostalCode { get; set; }

        [JsonPropertyName("Region")]
        public Region Region { get; set; }

        [JsonPropertyName("Country")]
        public Country Country { get; set; }

        [JsonPropertyName("AdministrativeArea")]
        public AdministrativeArea AdministrativeArea { get; set; }

        [JsonPropertyName("TimeZone")]
        public TimeZone TimeZone { get; set; }

        [JsonPropertyName("GeoPosition")]
        public GeoPosition GeoPosition { get; set; }

        [JsonPropertyName("IsAlias")]
        public bool IsAlias { get; set; }

        [JsonPropertyName("SupplementalAdminAreas")]
        public List<SupplementalAdminArea> SupplementalAdminAreas { get; set; }

        [JsonPropertyName("DataSets")]
        public List<string> DataSets { get; set; }
    }
}
