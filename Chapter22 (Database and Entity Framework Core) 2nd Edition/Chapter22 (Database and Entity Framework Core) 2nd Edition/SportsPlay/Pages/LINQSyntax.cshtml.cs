using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace SportsPlay.Pages;

public class LINQSyntaxModel : PageModel
{

    private readonly SportsPlay.Models.SportsPlayContext SportsPlayContext;
    public LINQSyntaxModel(SportsPlay.Models.SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public class Result
    {
        public string? Category;
        public string? Supplier;
        public string? Product;
        public decimal? Price;
    }

    private IQueryable<Result> ResultIQueryable;
    public IList<Result> ResultIList;

    public async Task OnGetAsync()
    {

        // Define the database query (LINQ query syntax).
        ResultIQueryable = (
            from p in SportsPlayContext.Product
            join c in SportsPlayContext.Category on p.CategoryID equals c.CategoryID
            join s in SportsPlayContext.Supplier on p.SupplierID equals s.SupplierID
            where p.Price >= 100
            orderby c.Category1, s.Supplier1, p.Price
            select new Result
            {
                Category = c.Category1,
                Supplier = s.Supplier1,
                Product = p.Product1,
                Price = p.Price
            });
        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

        // Display the results in the Output window.
        foreach (var item in ResultIList)
        {
            Debug.WriteLine(
                "[" + item.Category + "][" + item.Supplier + "]" +
                "[" + item.Product + "][" + item.Price + "]");
        }

        // Define the database query (LINQ method syntax).
        ResultIQueryable = SportsPlayContext.Product
            .Join(SportsPlayContext.Category, p => p.CategoryID, c => c.CategoryID, (p, c) => new { p, c })
            .Join(SportsPlayContext.Supplier, pc => pc.p.SupplierID, s => s.SupplierID, (pc, s) => new Result
            {
                Category = pc.c.Category1,
                Supplier = s.Supplier1,
                Product = pc.p.Product1,
                Price = pc.p.Price
            })
            .Where(p => p.Price >= 100)
            .OrderBy(c => c.Category).ThenBy(s => s.Supplier).ThenBy(p => p.Price);
        // Retrieve the rows for display.
        ResultIList = await ResultIQueryable.ToListAsync();

        // Display the results in the Output window.
        foreach (var item in ResultIList)
        {
            Debug.WriteLine(
                "[" + item.Category + "][" + item.Supplier + "]" +
                "[" + item.Product + "][" + item.Price + "]");
        }

    }

}