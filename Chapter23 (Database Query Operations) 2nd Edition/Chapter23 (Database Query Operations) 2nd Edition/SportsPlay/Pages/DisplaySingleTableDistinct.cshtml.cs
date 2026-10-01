using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages;

public class DisplaySingleTableDistinctModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public DisplaySingleTableDistinctModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public class Result
    {
        public String? State;
    }

    private IQueryable<Result> ResultIQueryable;
    public IList<Result> ResultIList;

    public async Task OnGetAsync()
    {

        // Define the database query.
        ResultIQueryable = (
            from c in SportsPlayContext.Customer
            group c by c.State into g
            orderby g.Key
            select new Result
            {
                State = g.Key
            });
        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

    }

}
