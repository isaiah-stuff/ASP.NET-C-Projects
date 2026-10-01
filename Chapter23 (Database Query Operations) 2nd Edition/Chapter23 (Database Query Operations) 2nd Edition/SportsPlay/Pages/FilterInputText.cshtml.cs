using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages;

[BindProperties]
public class FilterInputTextModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public FilterInputTextModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public string Filter { get; set; }

    public class Result
    {
        public string? Category;
        public string? Supplier;
        public string? Product;
        public string? Image;
        public decimal? Price;
    }

    private IQueryable<Result> ResultIQueryable;
    public IList<Result> ResultIList;

    public async Task OnGetAsync()
    {

        await RetrieveRowsForDisplay();

    }

    public async Task OnPostFilterAsync()
    {

        await RetrieveRowsForDisplay();

    }

    private async Task RetrieveRowsForDisplay()
    {

        // Define the database query.
        ResultIQueryable = (
            from p in SportsPlayContext.Product
            join c in SportsPlayContext.Category on p.CategoryID equals c.CategoryID
            join s in SportsPlayContext.Supplier on p.SupplierID equals s.SupplierID
            where p.Product1.Contains(Filter)
            orderby c.Category1, s.Supplier1, p.Product1
            select new Result
            {
                Category = c.Category1,
                Supplier = s.Supplier1,
                Product = p.Product1,
                Image = p.Image,
                Price = p.Price
            });

        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

    }

}