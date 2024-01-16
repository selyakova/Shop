using Shop.Core.Dto.AccuWeatherDtos;

namespace Shop.Core.ServiceInterface
{
    public interface IAccuWeatherForecastServices
    {
        Task<AccuWeatherResultDto> AccuWeatherResult(AccuWeatherResultDto dto);
    }
}
