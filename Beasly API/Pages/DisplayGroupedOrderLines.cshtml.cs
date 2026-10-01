using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Chapter23.Models;

namespace Stuffle.Isaiah.Chapter23.Pages;
public class DisplayGroupedOrderLinesModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public DisplayGroupedOrderLinesModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public class Result
    {
        public int? OrderID;
        public DateTime? Date;
        public decimal? OrderLines;
        public decimal? SumOfPrices;
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
            from ol in SportsPlayContext.OrderLine
            join o in SportsPlayContext.Order on ol.OrderID equals o.OrderID
            group ol by new {ol.OrderID, o.Date} into g
            orderby g.Key.OrderID
            select new Result
            {
                OrderID = g.Key.OrderID,
                OrderLines = g.Count(),
                SumOfPrices = g.Sum(g => g.Price),
                Average = g.Average(g => g.Price),
                Maximum = g.Max(g => g.Price),
                Minimum = g.Min(g => g.Price)
            });
        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

    }

}
