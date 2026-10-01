using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages.Products;

[BindProperties]
public class AddProductModel : PageModel
{

    public string MessageColor;
    public string Message;

    private readonly SportsPlayContext SportsPlayContext;
    public AddProductModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public SelectList CategorySelectList;
    public SelectList SupplierSelectList;

    public Product Product { get; set; }

    public void OnGet()
    {

        // Set the message.
        MessageColor = "Green";
        Message = "Please add the information below and click Add.";

        // Populate the category select list.
        CategorySelectList = new SelectList(SportsPlayContext.Category
            .OrderBy(c => c.Category1), "CategoryID", "Category1");

        // Populate the supplier select list.
        SupplierSelectList = new SelectList(SportsPlayContext.Supplier
            .OrderBy(s => s.Supplier1), "SupplierID", "Supplier1");

    }

    public async Task<IActionResult> OnPostAddAsync()
    {

        try
        {
            // Add the row to the table.
            SportsPlayContext.Product.Add(Product);
            await SportsPlayContext.SaveChangesAsync();
            // Set the message.
            TempData["strMessageColor"] = "Green";
            TempData["strMessage"] = Product.Product1 + " was successfully added.";
        }
        catch (DbUpdateException objDbUpdateException)
        {
            // A database exception occurred while saving to the
            // database.
            // Set the message.
            TempData["strMessageColor"] = "Red";
            TempData["strMessage"] = Product.Product1 + " was NOT added. Please report this message to...: " + objDbUpdateException.InnerException.Message;
        }
        return Redirect("MaintainProducts");

    }

}
