using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter17.Pages.Home
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            ViewData["Page"] = "Privacy";
            ViewData["User"] = HttpContext.Session.GetString("strUser");
            ViewData["UserStatus"] = HttpContext.Session.GetString("strUserStatus");
            ViewData["MessageColor"] = "Green";
            ViewData["Message"] = "Please read the privacy statement below";
        }
    }

}
