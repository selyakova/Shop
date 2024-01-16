using Shop.Core.Dto.ChuckNorrisDtos;

namespace Shop.Core.ServiceInterface
{
    public interface IChuckNorrisServices
    {
        Task<ChuckNorrisResultDto> ChuckNorrisResult(ChuckNorrisResultDto dto);
    }
}
