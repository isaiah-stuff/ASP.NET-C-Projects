using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Chapter23.Models;

namespace Stuffle.Isaiah.Chapter23.Pages;
public class FilterCustomersWithTextModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public FilterCustomersWithTextModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public string Filter { get; set; }

    public class Result
    {
        public string? LastName;
        public string? FirstName;
        public string? MiddleInitial;
    }

    private IQueryable<Customer> CustomerIQueryable;
    public IList<Customer> CustomerIList;

    public async Task OnGetAsync()
    {

        await RetrieveRowsForDisplay();

    }
    public async Task OnPostFilterAsync()
    {

        await RetrieveRowsForDisplay();

    }


    public async Task RetrieveRowsForDisplay()
    {

        // Define the database query.
        CustomerIQueryable = (
            from c in SportsPlayContext.Customer
            where c.LastName.Contains(Filter) || c.FirstName.Contains(Filter) || c.MiddleInitial.Contains(Filter)
            orderby c.LastName, c.FirstName, c.MiddleInitial
            select c);
        // Retrieve the rows for display.
        CustomerIList = await CustomerIQueryable.ToListAsync();

    }

}