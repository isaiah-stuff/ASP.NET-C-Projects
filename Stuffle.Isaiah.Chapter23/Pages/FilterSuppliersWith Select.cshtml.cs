using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Chapter23.Models;

namespace Stuffle.Isaiah.Chapter23.Pages;
    public class FilterSuppliersWith_SelectModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public FilterSuppliersWith_SelectModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public int CategoryID { get; set; }
    public SelectList SupplierSelectList;

    public class Result
    {
        public string? Supplier;
        public string? Product;
        public decimal? Price;
    }

    private IQueryable<Result> ResultIQueryable;
    public IList<Result> ResultIList;

    public async Task OnGetAsync()
    {

        PopulateSelectList();
        await RetrieveRowsForDisplay();

    }

    public async Task OnPostFilterAsync()
    {

        PopulateSelectList();
        await RetrieveRowsForDisplay();

    }

    private void PopulateSelectList()
    {

        // Populate the select list.
        SupplierSelectList = new SelectList(SportsPlayContext.Supplier
            .OrderBy(s => s.Supplier1), "Product");

    }

    private async Task RetrieveRowsForDisplay()
    {

        // Define the database query.
        ResultIQueryable = (
            from p in SportsPlayContext.Product
            join s in SportsPlayContext.Supplier on p.SupplierID equals s.SupplierID
            where p.CategoryID == CategoryID
            orderby s.Supplier1, p.Product1
            select new Result
            {
                Supplier = s.Supplier1,
                Product = p.Product1,
            });

        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

    }

}