using Shop.Core.Domain;
using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
    public interface IKindergartenServices
    {
        Task<Kindergarten> GetAsync(Guid id);
        Task<Kindergarten> Create(KindergartenDto dto);

        Task<Kindergarten> Delete(Guid id);
        Task<Kindergarten> Update(KindergartenDto dto);
    }
}
