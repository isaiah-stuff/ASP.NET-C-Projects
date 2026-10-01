using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages.Products;

public class DeleteProductModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public DeleteProductModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    private Product Product { get; set; }

    public async Task<IActionResult> OnGetAsync(int intProductID)
    {

        // Look up the row in the table to see if it still exists.
        Product = await SportsPlayContext.Product.FindAsync(intProductID);
        if (Product != null)
        {
            try
            {
                // Delete the row from the table.
                SportsPlayContext.Product.Remove(Product);
                await SportsPlayContext.SaveChangesAsync();
                // Set the message.
                TempData["strMessageColor"] = "Green";
                TempData["strMessage"] = Product.Product1 + " was successfully deleted.";
            }
            catch (DbUpdateException objDbUpdateException)
            {
                // A database exception occurred.
                SqlException objSqlException = objDbUpdateException.InnerException as SqlException;
                if (objSqlException.Number == 547)
                {
                    // A foreign key constraint database exception
                    // occurred.
                    // Set the message.
                    TempData["strMessageColor"] = "Red";
                    TempData["strMessage"] = Product.Product1 + " was NOT deleted because it is associated with one or more order lines. To delete this product, you must first delete the associated order lines.";
                }
                else
                {
                    // A database exception occurred while saving to
                    // the database.
                    // Set the message.
                    TempData["strMessageColor"] = "Red";
                    TempData["strMessage"] = Product.Product1 + " was NOT deleted. Please report this message to...: " + objDbUpdateException.InnerException.Message;
                }
            }
        }
        else
        {
            // Even though someone else deleted the item first, still
            // inform the user that the item was deleted successfully.
            // Set the message.
            TempData["strMessageColor"] = "Green";
            TempData["strMessage"] = "The product was successfully deleted.";
        }
        return Redirect("MaintainProducts");

    }

}
