using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages;

[BindProperties]
public class FilterSelectAsynchronousPopulationModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public FilterSelectAsynchronousPopulationModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public int EmployeeID { get; set; }
    public SelectList EmployeeSelectList;

    public int OrderID { get; set; }
    public SelectList OrderSelectList;

    public class Result
    {
        public int? EmployeeID;
        public int? OrderID;
        public string? Date;
        public string? LastName;
        public string? FirstName;
        public string? MiddleInitial;
    }

    private IQueryable<Result> ResultIQueryable;
    public IList<Result> ResultIList;

    public async Task OnGetAsync()
    {

        PopulateEmployeeSelectList();
        await RetrieveRowsForDisplay();

    }

    public async Task OnPostFilterAsync()
    {

        PopulateEmployeeSelectList();
        OnGetPopulateOrderSelectList(EmployeeID);
        await RetrieveRowsForDisplay();

    }

    private void PopulateEmployeeSelectList()
    {

        // Populate the employee select list.
        EmployeeSelectList = new SelectList(SportsPlayContext.Employee
            .OrderBy(e => e.LastName), "EmployeeID", "LastName");

    }

    public void OnGetPopulateOrderSelectList(int EmployeeID)
    {

        // Populate the order select list.
        OrderSelectList = new SelectList(SportsPlayContext.Order
            .Where(o => o.EmployeeID == EmployeeID)
            .OrderBy(o => o.OrderID), "OrderID", "OrderID");

    }

    private async Task RetrieveRowsForDisplay()
    {

        // Define the database query.
        ResultIQueryable = (
            from o in SportsPlayContext.Order
            where o.EmployeeID == EmployeeID
               && o.OrderID == OrderID
            select new Result
            {
                OrderID = o.OrderID,
                Date = o.Date.ToString(),
                LastName = o.LastName,
                FirstName = o.FirstName,
                MiddleInitial = o.MiddleInitial
            });

        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

    }

}