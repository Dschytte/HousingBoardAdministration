namespace HousingBoardApi.Domain.Mail
{
    public class MailSettings
    {
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Sender { get; set; }
        public string HostUrl { get; set; }
    }
}
