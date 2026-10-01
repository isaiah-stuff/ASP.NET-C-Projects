using System.Net.Mail;

namespace SportsPlay.Services;

public class EmailServiceNetMail : IEmailService
{

    private readonly IConfiguration IConfiguration;
    public EmailServiceNetMail(IConfiguration IC)
    {
        IConfiguration = IC;
    }

    public async Task SendEmail(string strToName, string strToAddress, string strSubject, string strBody)
    {

        // Build the email message.
        MailMessage objMailMessage = new MailMessage();
        objMailMessage.From = new MailAddress("noreply@sportsplay.com", "No Reply");
        objMailMessage.To.Add(new MailAddress(strToAddress, strToName));
        objMailMessage.Subject = strSubject;
        objMailMessage.IsBodyHtml = true;
        objMailMessage.Body = strBody;
        // Send the email message.
        SmtpClient objSmtpClient = new SmtpClient();
        objSmtpClient.Host = IConfiguration.GetValue<string>("Email:Host");
        objSmtpClient.Port = IConfiguration.GetValue<int>("Email:Port");
        await objSmtpClient.SendMailAsync(objMailMessage);
        objSmtpClient.Dispose();

    }

}
