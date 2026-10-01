using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter17.Pages.Home;
[BindProperties]
    public class InitializeModel : PageModel
    {
        public RedirectResult OnGet()
        {
        HttpContext.Session.Clear();

        HttpContext.Session.SetString("strUser", "*");
        HttpContext.Session.SetString("strUserStatus", "*");
        return Redirect("Home/Log In");
    }
    }
