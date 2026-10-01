using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Chapter23.Models;

namespace Stuffle.Isaiah.Chapter23.Pages;
public class DisplayDistinctProductIDsModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public DisplayDistinctProductIDsModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public class Result
    {
        public String? Product1;
    }

    private IQueryable<Result> ResultIQueryable;
    public IList<Result> ResultIList;

    public async Task OnGetAsync()
    {

        // Define the database query.
        ResultIQueryable = (
            from p in SportsPlayContext.Product
            group p by p.Product1 into g
            orderby g.Key
            select new Result
            {
                Product1 = g.Key
            });
        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

    }

}