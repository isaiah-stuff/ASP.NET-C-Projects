using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages.Products;

public class MaintainProductsModel : PageModel
{

    public string MessageColor;
    public string Message;

    private readonly SportsPlayContext SportsPlayContext;
    public MaintainProductsModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public class Result
    {
        public string? Category;
        public string? Supplier;
        public int? ProductID;
        public string? Product;
    }

    private IQueryable<Result> ResultIQueryable;
    public IList<Result> ResultIList;

    public async Task OnGetAsync()
    {

        // Set the message.
        if (TempData["strMessage"] == null)
        {
            TempData["strMessageColor"] = "Green";
            TempData["strMessage"] = "Please choose an option below.";
        }
        else
        {
            MessageColor = TempData["strMessageColor"].ToString();
            Message = TempData["strMessage"].ToString();
        }

        // Define the database query.
        ResultIQueryable = (
            from p in SportsPlayContext.Product
            join c in SportsPlayContext.Category on p.CategoryID equals c.CategoryID
            join s in SportsPlayContext.Supplier on p.SupplierID equals s.SupplierID
            orderby c.Category1, s.Supplier1, p.Product1
            select new Result
            {
                Category = c.Category1,
                Supplier = s.Supplier1,
                ProductID = p.ProductID,
                Product = p.Product1
            });
        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

    }

}