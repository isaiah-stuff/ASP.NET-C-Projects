using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ch21HMk.Services;
using System.Net.Mail;

namespace Ch21HMk.Pages;

[BindProperties]
public class SendEmailModel : PageModel
{
    private readonly IEmailService IEmailService;

    //instructor method
    public SendEmailModel(IEmailService IES)
    {
        IEmailService = IES;
    }

    public string MessageColor;
    public string PageMessage;

    public string From { get; set; }
    public string To { get; set; }
    public string CC { get; set; }
    public string BCC { get; set; }
    public string Subject { get; set; }
    public string TextFormat { get; set; }
    public string Message { get; set; }


    public void OnGet()
    {
    }
    public async Task OnPostSend()
{
        // Configure the email message and send it.
        string strFrom = From;
        string strTo = To;
        string strCC = CC;
        string strBCC = BCC;
        string strSubject = Subject;
        string strTextFormat = TextFormat;
        string strMessage = "Dear " + strTo + "," + "<br /><br />Your password has been changed. If you changed your password, you may ignore this message. If you did <i>not</i> change your password, please contact the SportsPlay Fraud Hotline immediately at 1-800-555-1212.<br /><br />Thank you,<br /><br />The SportsPlay System";
        await IEmailService.SendEmail(strFrom,  strTo,  strCC, strBCC, strSubject, strTextFormat, strMessage);
        // Set the message.
        MessageColor = "Green";
        PageMessage = "Your password has been successfully changed.";
    }
        
}
