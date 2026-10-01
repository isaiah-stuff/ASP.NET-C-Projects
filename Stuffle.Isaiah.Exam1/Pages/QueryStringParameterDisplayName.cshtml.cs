using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Exam1.Pages;
[BindProperties]
public class QueryStringParameterDisplayNameModel : PageModel
    {
        public string MessageColor;
        public string Message;
        public void OnGet()
        {
            string Name = Request.Query["Name"];

            Message = "Your name is " + Name + ".";
        }
    }
