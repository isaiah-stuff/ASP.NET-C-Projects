using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter17.Pages.Home;
[BindProperties]

    public class Log_InModel : PageModel
    {
    public string Username { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public void OnGet()
    {
        // Set the header data.
        ViewData["Page"] = "Log In";
        ViewData["User"] = HttpContext.Session.GetString("strUser");
        ViewData["UserStatus"] = HttpContext.Session.GetString("strUserStatus");

        if (TempData["strMessageColor"] == null)
        {
            ViewData["MessageColor"] = "Green";
            ViewData["Message"] = "Please log in.";
        }
        else
        {
            ViewData["MessageColor"] = TempData["strMessageColor"];
            ViewData["Message"] = TempData["strMessage"];
        }
    }
    public RedirectResult OnPostLogIn()
    {

        // Log in the user.
        if (EmailAddress == "rregal@sportsplay.com" && Password == "abc")
        {
            // Save the user's information.
            HttpContext.Session.SetString("strUser", "Richard R Regal");
            HttpContext.Session.SetString("strUserStatus", "M");
            // Redirect the user.
            return Redirect("Welcome");
        }
        else if (EmailAddress == "bbillingsley@sportsplay.com" && Password == "abc")
        {
            // Save the user's information.
            HttpContext.Session.SetString("strUser", "Beth B Billingsley");
            HttpContext.Session.SetString("strUserStatus", "S");
            // Redirect the user.
            return Redirect("Welcome");
        }
        else if (EmailAddress == "jjones@somemail.com" && Password == "abc")
        {
            // Save the user's information.
            HttpContext.Session.SetString("strUser", "Jacob J Jones");
            HttpContext.Session.SetString("strUserStatus", "C");
            // Redirect the user.
            return Redirect("Welcome");
        }
        else
        {
            // Set the message.
            TempData["strMessageColor"] = "Red";
            TempData["strMessage"] = "You have entered an invalid email address and password combination. Please try again.";
            // Redirect the user.
            return Redirect("LogIn");
        }
        
    }
}
