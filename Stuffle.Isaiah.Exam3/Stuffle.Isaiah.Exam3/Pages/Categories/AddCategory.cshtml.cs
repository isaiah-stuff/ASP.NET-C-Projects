using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Exam3.Models;

namespace Stuffle.Isaiah.Exam3.Pages.Categories;

[BindProperties]
public class AddCategoryModel : PageModel
{

    public string MessageColor;
    public string Message;

    private readonly SportsPlayContext SportsPlayContext;
    public AddCategoryModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public SelectList CategorySelectList;

    public Category Category { get; set; }

    public void OnGet()
    {

        // Set the message.
        MessageColor = "Green";
        Message = "Please add the information below and click Add.";

        // Populate the category select list.
        CategorySelectList = new SelectList(SportsPlayContext.Category
            .OrderBy(c => c.Category1), "CategoryID", "Category1");

    }

    public async Task<IActionResult> OnPostAddAsync()
    {

        try
        {
            // Add the row to the table.
            SportsPlayContext.Category.Add(Category);
            await SportsPlayContext.SaveChangesAsync();
            // Set the message.
            TempData["strMessageColor"] = "Green";
            TempData["strMessage"] = Category.Category1 + " was successfully added.";
        }
        catch (DbUpdateException objDbUpdateException)
        {
            // A database exception occurred while saving to the
            // database.
            // Set the message.
            TempData["strMessageColor"] = "Red";
            TempData["strMessage"] = Category.Category1 + " was NOT added. Please report this message to...: " + objDbUpdateException.InnerException.Message;
        }
        return Redirect("MaintainCategories");

    }

}