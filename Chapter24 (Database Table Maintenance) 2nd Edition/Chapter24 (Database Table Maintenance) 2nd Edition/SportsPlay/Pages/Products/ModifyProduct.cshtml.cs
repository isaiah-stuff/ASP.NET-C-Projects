using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages.Products;

[BindProperties]
public class ModifyProductModel : PageModel
{

    public string MessageColor;
    public string Message;

    private readonly SportsPlayContext SportsPlayContext;
    public ModifyProductModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public SelectList CategorySelectList;
    public SelectList SupplierSelectList;

    public Product Product { get; set; }

    public async Task<IActionResult> OnGetAsync(int intProductID)
    {

        // Set the message.
        MessageColor = "Green";
        Message = "Please modify the information below and click Modify.";

        // Attempt to retrieve the row from the table.
        Product = await SportsPlayContext.Product.FindAsync(intProductID);
        if (Product != null)
        {
            // Populate the category select list.
            CategorySelectList = new SelectList(SportsPlayContext.Category
                .OrderBy(c => c.Category1), "CategoryID", "Category1");
            // Populate the supplier select list.
            SupplierSelectList = new SelectList(SportsPlayContext.Supplier
                .OrderBy(s => s.Supplier1), "SupplierID", "Supplier1");
            return Page();
        }
        else
        {
            // Set the message.
            TempData["strMessageColor"] = "Red";
            TempData["strMessage"] = "The selected product was deleted by someone else.";
            return Redirect("MaintainProducts");
        }

    }

    public async Task<IActionResult> OnPostModifyAsync()
    {

        try
        {
            // Modify the row in the table.
            SportsPlayContext.Product.Update(Product);
            await SportsPlayContext.SaveChangesAsync();
            // Set the message.
            TempData["strMessageColor"] = "Green";
            TempData["strMessage"] = Product.Product1 + " was successfully modified.";
        }
        catch (DbUpdateException objDbUpdateException)
        {
            // A database exception occurred while saving to the
            // database.
            // Set the message.
            TempData["strMessageColor"] = "Red";
            TempData["strMessage"] = Product.Product1 + " was NOT modified. Please report this message to...: " + objDbUpdateException.InnerException.Message;
        }
        return Redirect("MaintainProducts");

    }

}
