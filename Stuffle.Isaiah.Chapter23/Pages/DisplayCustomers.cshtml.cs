using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Chapter23.Models;

namespace Stuffle.Isaiah.Chapter23.Pages;
public class DisplayCustomersModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public DisplayCustomersModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    private IQueryable<Customer> CustomerIQueryable;
    public IList<Customer> CustomerIList;

    public async Task OnGetAsync()
    {

        // Define the database query.
        CustomerIQueryable = (
            from c in SportsPlayContext.Customer
            orderby c.LastName, c.FirstName, c.MiddleInitial
            select c);
        // Retrieve the rows for display.
        CustomerIList = await CustomerIQueryable.ToListAsync();

    }

}