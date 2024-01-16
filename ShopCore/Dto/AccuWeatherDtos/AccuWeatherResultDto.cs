namespace Shop.Core.Dto.AccuWeatherDtos
{
    public class AccuWeatherResultDto
    {
        public string City { get; set; }
        public string Key { get; set; }
        public int TemperatureMin { get; set; }
        public int TemperatureMax { get; set; }
        public string Link { get; set; }
    }
}
