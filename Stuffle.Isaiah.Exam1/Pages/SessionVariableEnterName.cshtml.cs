using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Exam1.Pages;
[BindProperties]
public class SessionVariableEnterNameModel : PageModel
{
    public string Name { get; set; }
    public string Message;
    public void OnGet()
    {
    }

    public RedirectResult OnPostPassSessionVariable()
    {
        HttpContext.Session.SetString("Name", Name);
        return Redirect("SessionVariableDisplayName");
    }
}
