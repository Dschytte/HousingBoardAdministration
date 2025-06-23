using HousingBoardApi.Domain.Mail;

namespace HousingBoardApi.Application.Messages
{
    public interface IMailService
    {

        void SendEmail(MailRequest mail);
    }
}
