using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SportsPlay.Pages.Products;

public class CancelProductModel : PageModel
{

    public RedirectResult OnGet()
    {

        // Set the message.
        TempData["strMessageColor"] = "Red";
        TempData["strMessage"] = "The operation was cancelled. No data was affected.";
        return Redirect("MaintainProducts");

    }

}
