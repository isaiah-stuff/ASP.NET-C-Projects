using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages;

public class DisplaySingleTableModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public DisplaySingleTableModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    private IQueryable<Product> ProductIQueryable;
    public IList<Product> ProductIList;

    public async Task OnGetAsync()
    {

        // Define the database query.
        ProductIQueryable = (
            from p in SportsPlayContext.Product
            orderby p.Product1
            select p);
        // Retrieve the rows for display.
        ProductIList = await ProductIQueryable.ToListAsync();

    }

}