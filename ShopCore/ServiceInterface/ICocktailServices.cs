using Shop.Core.Dto.CocktailsDtos;

namespace Shop.Core.ServiceInterface
{
    public interface ICocktailServices
    {
        Task<CocktailResultDto> GetCocktails(CocktailResultDto dto);
    }
}
