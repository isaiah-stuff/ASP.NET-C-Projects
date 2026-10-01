using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Exam3.Models;

namespace Stuffle.Isaiah.Exam3.Pages.Categories;
[BindProperties]
    public class DeleteCategoryModel : PageModel
    {

        private readonly SportsPlayContext SportsPlayContext;
        public DeleteCategoryModel(SportsPlayContext SPC)
        {
            SportsPlayContext = SPC;
        }

        private Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int intCategoryID)
        {

            // Look up the row in the table to see if it still exists.
            Category = await SportsPlayContext.Category.FindAsync(intCategoryID);
            if (Category != null)
            {
                try
                {
                    // Delete the row from the table.
                    SportsPlayContext.Category.Remove(Category);
                    await SportsPlayContext.SaveChangesAsync();
                    // Set the message.
                    TempData["strMessageColor"] = "Green";
                    TempData["strMessage"] = Category.Category1 + " was successfully deleted.";
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
                        TempData["strMessage"] = Category.Category1 + " was NOT deleted because it is associated with one or more order lines. To delete this product, you must first delete the associated order lines.";
                    }
                    else
                    {
                        // A database exception occurred while saving to
                        // the database.
                        // Set the message.
                        TempData["strMessageColor"] = "Red";
                        TempData["strMessage"] = Category.Category1 + " was NOT deleted. Please report this message to...: " + objDbUpdateException.InnerException.Message;
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
            return Redirect("MaintainCategories");

        }

    }