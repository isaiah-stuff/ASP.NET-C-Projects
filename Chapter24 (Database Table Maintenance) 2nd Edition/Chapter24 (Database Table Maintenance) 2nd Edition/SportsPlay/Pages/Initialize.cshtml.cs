using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportsPlay.Pages;

public class InitializeModel : PageModel
{

    public RedirectResult OnGet()
    {

        // Initialize the message.
        TempData["strMessageColor"] = "Green";
        TempData["strMessage"] = "Please choose an option below.";
        return Redirect("/Products/MaintainProducts");

    }

}
