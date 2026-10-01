using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsPlay.Services;

namespace SportsPlay.Pages;

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
    public string Message;

    public string EmailAddress { get; set; }
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public string NewPasswordRepeat { get; set; }

    public void OnGet()
    {
    }

    public async Task OnPostChangePasswordAsync()
    {

        // Make sure the user entered the new password twice.
        if (NewPassword == NewPasswordRepeat)
        {
            // Confirm the user's credentials.
            if (EmailAddress == "rregal@sportsplay.com" && CurrentPassword == "abc")
            {
                string strFullName = "Richard R Regal";
                // Configure the email message and send it.
                string strToName = strFullName;
                string strToAddress = EmailAddress;
                string strSubject = "SportsPlay Password Change";
                string strBody = "Dear " + strFullName + "," + "<br /><br />Your password has been changed. If you changed your password, you may ignore this message. If you did <i>not</i> change your password, please contact the SportsPlay Fraud Hotline immediately at 1-800-555-1212.<br /><br />Thank you,<br /><br />The SportsPlay System";
                await IEmailService.SendEmail(strToName, strToAddress, strSubject, strBody);
                // Set the message.
                MessageColor = "Green";
                Message = "Your password has been successfully changed.";
            }
            else
            {
                // Set the message.
                MessageColor = "Red";
                Message = "You have entered an invalid email address and password combination. Please try again.";
            }
        }
        else
        {
            // Set the message.
            MessageColor = "Red";
            Message = "You must enter the new password twice. Please try again.";
        }

    }

}