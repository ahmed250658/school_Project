using MailKit.Net.Smtp;
using MimeKit;
using school_Project.Data.Helper;
using school_Project.Service.Abstracts;


namespace school_Project.Service.Impelementions
{
    public class EmailService : IEmailService
    {
        #region Fields
        private readonly EamilSetting _eamilSetting;
        #endregion

        #region Constructor
        public EmailService(EamilSetting eamilSetting)
        {
            _eamilSetting = eamilSetting;
        }
        #endregion

        #region Handle Functions
        public async Task<string> SendEmail(string email, string Message, string? reason)
        {
            try
            {
                //sending the Message of passwordResetLink
                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(_eamilSetting.Host, _eamilSetting.Port, true);
                    client.Authenticate(_eamilSetting.FromEmail, _eamilSetting.Password);
                    var bodybuilder = new BodyBuilder
                    {
                        HtmlBody = $"{Message}",
                        TextBody = "wellcome",
                    };
                    var message = new MimeMessage
                    {
                        Body = bodybuilder.ToMessageBody()
                    };
                    message.From.Add(new MailboxAddress("Future Team", _eamilSetting.FromEmail));
                    message.To.Add(new MailboxAddress("testing", email));
                    message.Subject = reason == null ? "No Submitted" : reason;
                    await client.SendAsync(message);
                    await client.DisconnectAsync(true);
                }
                //end of sending email
                return "Success";
            }
            catch (Exception ex)
            {
                return "Failed";
            }
        }
        #endregion

    }
}
