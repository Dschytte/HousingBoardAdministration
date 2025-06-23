using HousingBoardApi.Application.Messages;
using HousingBoardApi.Domain.Mail;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace HousingBoardApi.Infrastructure.Messages
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;

        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        void IMailService.SendEmail(MailRequest mail)
        {
            var smtpClient = new SmtpClient(_mailSettings.HostUrl)
            {
                Port = _mailSettings.Port,
                Credentials = new NetworkCredential(_mailSettings.Username, _mailSettings.Password),
                EnableSsl = true,
            };

            foreach (string emailAddress in mail.RecipientEmailAddresses)
            {
                smtpClient.Send(_mailSettings.Sender, emailAddress, mail.Subject, mail.Body);
            }

        }
    }
}
