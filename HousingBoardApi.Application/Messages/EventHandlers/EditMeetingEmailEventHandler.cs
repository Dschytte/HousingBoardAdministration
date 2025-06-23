using HousingBoardApi.Application.IRepositories;
using HousingBoardApi.Application.Messages.Events;
using HousingBoardApi.Domain.Mail;

namespace HousingBoardApi.Application.Messages.EventHandlers
{
    public class EditMeetingEmailEventHandler : INotificationHandler<EditMeetingEmailEvent>
    {
        private readonly IBoardMemberRepository _boardMemberRepository;
        private readonly IMailService _mailService;

        public EditMeetingEmailEventHandler(IBoardMemberRepository boardMemberRepository, IMailService mailService)
        {
            _boardMemberRepository = boardMemberRepository;
            _mailService = mailService;
        }


        Task INotificationHandler<EditMeetingEmailEvent>.Handle(EditMeetingEmailEvent notification, CancellationToken cancellationToken)
        {
            MailRequest mailRequest = new MailRequest
            {
                Subject = $"Ændring af møde: {notification.Title}",
                Body = $"Mødet foregår på addressen {notification.AddressLocation}, på datoen {notification.MeetingTime.ToString("dd, MM, yyyy")}, " +
                        $"klokken {notification.MeetingTime.ToString("HH")}",
                RecipientEmailAddresses = _boardMemberRepository.GetAll().Select(b => b.UserName).ToList()
            };

            _mailService.SendEmail(mailRequest);
            return Task.CompletedTask;
        }
    }
}
