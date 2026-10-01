using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Exam1.Pages;
[BindProperties]
public class SessionVariableDisplayNameModel : PageModel
    {
    public string MessageColor;
    public string Message;
        public void OnGet()
        {
        string Name = HttpContext.Session.GetString("Name");

        Message = "Your name is " + Name + ".";
    }
    }
