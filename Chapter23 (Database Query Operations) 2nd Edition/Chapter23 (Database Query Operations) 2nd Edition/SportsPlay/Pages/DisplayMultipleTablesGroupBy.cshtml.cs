using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages;

public class DisplayMultipleTablesGroupByModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public DisplayMultipleTablesGroupByModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public class Result
    {
        public string? Category;
        public int? Count;
        public decimal? Sum;
        public decimal? Average;
        public decimal? Maximum;
        public decimal? Minimum;
    }

    private IQueryable<Result> ResultIQueryable;
    public IList<Result> ResultIList;

    public async Task OnGetAsync()
    {

        // Define the database query.
        ResultIQueryable = (
            from p in SportsPlayContext.Product
            join c in SportsPlayContext.Category on p.CategoryID equals c.CategoryID
            group p by new { c.CategoryID, c.Category1 } into g
            orderby g.Key.Category1
            select new Result
            {
                Category = g.Key.Category1,
                Count = g.Count(),
                Sum = g.Sum(g => g.Price),
                Average = g.Average(g => g.Price),
                Maximum = g.Max(g => g.Price),
                Minimum = g.Min(g => g.Price)
            });
        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

    }

}
