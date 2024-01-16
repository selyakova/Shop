using Shop.Core.Dto;

namespace Shop.Core.ServiceInterface
{
    public interface IEmailServices : IApplicationServices
    {
        public void SendEmail(EmailDto dto);
    }
}
