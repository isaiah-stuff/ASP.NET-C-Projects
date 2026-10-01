using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Exam3.Pages.Categories;
[BindProperties]
    public class CancelCategoryModel : PageModel
{

    public RedirectResult OnGet()
    {

        // Set the message.
        TempData["strMessageColor"] = "Red";
        TempData["strMessage"] = "The operation was cancelled. No data was affected.";
        return Redirect("MaintainCategories");

    }

}
