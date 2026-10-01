using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace Stuffle.Isaiah.Exam2.Services;

public class EmailServiceMailKit : IEmailService
{
    //dependency injection
    private readonly IConfiguration IConfiguration;
    public EmailServiceMailKit(IConfiguration IC)
    {
        //gives access to iconfiguration file in the appsettings.json file
        IConfiguration = IC;
    }

    public async Task SendEmail(string strFrom, string strTo, string strSubject, string strMessage)
    {
        // Build the email message.
        MimeMessage objMimeMessage = new MimeMessage();
        objMimeMessage.From.Add(new MailboxAddress("No Reply", "noreply@gmail.com"));
        objMimeMessage.To.Add(new MailboxAddress("", strTo));
        objMimeMessage.Subject = strSubject;
        // Send the email message.
        SmtpClient objSmtpClient = new SmtpClient();
        string strHost = IConfiguration.GetValue<string>("Email:Host");
        int intPort = IConfiguration.GetValue<int>("Email:Port");
        await objSmtpClient.ConnectAsync(strHost, intPort);
        await objSmtpClient.SendAsync(objMimeMessage);
        await objSmtpClient.DisconnectAsync(true);

    }

}
