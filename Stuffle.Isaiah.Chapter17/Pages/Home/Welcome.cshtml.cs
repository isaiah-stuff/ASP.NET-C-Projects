using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter17.Pages.Home;
[BindProperties]
    public class WelcomeModel : PageModel
    {
        public void OnGet()
        {
        // Set the header data.
        ViewData["Page"] = "Welcome";
        ViewData["User"] = HttpContext.Session.GetString("strUser");
        ViewData["UserStatus"] = HttpContext.Session.GetString("strUserStatus");
        ViewData["MessageColor"] = "Green";
        ViewData["Message"] = "Welcome to SportsPlay!";
    }
    }
