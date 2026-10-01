using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Exam1.Pages;
[BindProperties]
public class QueryStringParameterEnterNameModel : PageModel
    {
        public string Name { get; set; }
        public string Message;
        public void OnGet()
        {
        }

        public RedirectResult OnPostPassQueryStringParameter()
        {
            return Redirect($"/QueryStringParameterDisplayName" +
                $"?Name={Name}");
        }
    }

