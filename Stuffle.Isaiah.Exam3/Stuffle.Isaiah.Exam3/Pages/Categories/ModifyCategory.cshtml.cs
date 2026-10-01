using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Exam3.Models;

namespace Stuffle.Isaiah.Exam3.Pages.Categories;

[BindProperties]
public class ModifyCategoryModel : PageModel
{

    public string MessageColor;
    public string Message;

    private readonly SportsPlayContext SportsPlayContext;
    public ModifyCategoryModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public SelectList CategorySelectList;

    public Category Category { get; set; }

    public async Task<IActionResult> OnGetAsync(int intCategoryID)
    {

        // Set the message.
        MessageColor = "Green";
        Message = "Please modify the information below and click Modify.";

        // Attempt to retrieve the row from the table.
        Category = await SportsPlayContext.Category.FindAsync(intCategoryID);
        if (Category != null)
        {
            // Populate the category select list.
            CategorySelectList = new SelectList(SportsPlayContext.Category
                .OrderBy(c => c.Category1), "CategoryID", "Category1");
            return Page();
        }
        else
        {
            // Set the message.
            TempData["strMessageColor"] = "Red";
            TempData["strMessage"] = "The selected product was deleted by someone else.";
            return Redirect("MaintainCategories");
        }

    }

    public async Task<IActionResult> OnPostModifyAsync()
    {

        try
        {
            // Modify the row in the table.
            SportsPlayContext.Category.Update(Category);
            await SportsPlayContext.SaveChangesAsync();
            // Set the message.
            TempData["strMessageColor"] = "Green";
            TempData["strMessage"] = Category.Category1 + " was successfully modified.";
        }
        catch (DbUpdateException objDbUpdateException)
        {
            // A database exception occurred while saving to the
            // database.
            // Set the message.
            TempData["strMessageColor"] = "Red";
            TempData["strMessage"] = Category.Category1 + " was NOT modified. Please report this message to...: " + objDbUpdateException.InnerException.Message;
        }
        return Redirect("MaintainCategories");

    }

}
