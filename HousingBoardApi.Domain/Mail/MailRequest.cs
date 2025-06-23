namespace HousingBoardApi.Domain.Mail
{
    public class MailRequest
    {
        public List<String> RecipientEmailAddresses { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

    }
}
