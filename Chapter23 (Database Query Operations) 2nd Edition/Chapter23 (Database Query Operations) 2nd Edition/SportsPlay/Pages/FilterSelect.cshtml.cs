using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages;

[BindProperties]
public class FilterSelectModel : PageModel
{ 

    private readonly SportsPlayContext SportsPlayContext;
    public FilterSelectModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public int CategoryID { get; set; }
    public SelectList CategorySelectList;

    public class Result
    {
        public int? CategoryID;
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

        PopulateSelectList();
        await RetrieveRowsForDisplay();

    }

    public async Task OnPostFilterAsync()
    {

        PopulateSelectList();
        await RetrieveRowsForDisplay();

    }

    private void PopulateSelectList()
    {

        // Populate the select list.
        CategorySelectList = new SelectList(SportsPlayContext.Category
            .OrderBy(c => c.Category1), "CategoryID", "Category1");

    }

    private async Task RetrieveRowsForDisplay()
    {

        // Define the database query.
        ResultIQueryable = (
            from p in SportsPlayContext.Product
            join c in SportsPlayContext.Category on p.CategoryID equals c.CategoryID
            join s in SportsPlayContext.Supplier on p.SupplierID equals s.SupplierID
            where c.CategoryID == CategoryID
            orderby c.Category1, s.Supplier1, p.Product1
            select new Result
            {
                CategoryID = c.CategoryID,
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