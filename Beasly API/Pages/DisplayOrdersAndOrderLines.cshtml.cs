using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Stuffle.Isaiah.Chapter23.Models;

namespace Stuffle.Isaiah.Chapter23.Pages;
public class DisplayOrdersAndOrderLinesModel : PageModel
{
    private readonly SportsPlayContext SportsPlayContext;
    public DisplayOrdersAndOrderLinesModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public class Result
    {
        public int? OrderID;
        public int? OrderLineID;
        public DateTime? Date;
        public decimal? Price;
        public int? Quantity;
    }

    private IQueryable<Result> ResultIQueryable;
    public IList<Result> ResultIList;

    public async Task OnGetAsync()
    {
        ///still needs work
        /////
        ///
        //
        // Define the database query.
        ResultIQueryable = (
            from ol in SportsPlayContext.OrderLine
            join o in SportsPlayContext.Order on ol.OrderID equals o.OrderID
            orderby ol.OrderID, ol.OrderLineID
            select new Result
            {
                OrderID = ol.OrderID,
                OrderLineID= ol.OrderLineID,
                Date = o.Date,
                Price = ol.Price, 
                Quantity = ol.Quantity
            });
        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

    }

}
