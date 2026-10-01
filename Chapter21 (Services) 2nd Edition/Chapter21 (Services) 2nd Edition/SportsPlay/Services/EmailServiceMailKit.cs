using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace SportsPlay.Services;

public class EmailServiceMailKit : IEmailService
{
    //dependency injection
    private readonly IConfiguration IConfiguration;
    public EmailServiceMailKit(IConfiguration IC)
    {
        //gives access to iconfiguration file in the appsettings.json file
        IConfiguration = IC;
    }

    public async Task SendEmail(string strToName, string strToAddress, string strSubject, string strBody)
    {

        // Build the email message.
        MimeMessage objMimeMessage = new MimeMessage();
        objMimeMessage.From.Add(new MailboxAddress("No Reply", "noreply@sportsplay.com"));
        objMimeMessage.To.Add(new MailboxAddress(strToName, strToAddress));
        objMimeMessage.Subject = strSubject;
        objMimeMessage.Body = new TextPart(TextFormat.Html) { Text = strBody };
        // Send the email message.
        SmtpClient objSmtpClient = new SmtpClient();
        string strHost = IConfiguration.GetValue<string>("Email:Host");
        int intPort = IConfiguration.GetValue<int>("Email:Port");
        await objSmtpClient.ConnectAsync(strHost, intPort);
        await objSmtpClient.SendAsync(objMimeMessage);
        await objSmtpClient.DisconnectAsync(true);

    }

}
