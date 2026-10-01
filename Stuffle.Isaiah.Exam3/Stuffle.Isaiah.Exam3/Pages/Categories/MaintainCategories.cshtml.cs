using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Stuffle.Isaiah.Exam3.Models;

namespace Stuffle.Isaiah.Exam3.Pages.Categories;
    public class MaintainCategoriesModel : PageModel
    {

        public string MessageColor;
        public string Message;

        private readonly SportsPlayContext SportsPlayContext;
        public MaintainCategoriesModel(SportsPlayContext SPC)
        {
            SportsPlayContext = SPC;
        }

        public class Result
        {
        public int? CategoryID;
        public string? Category;

        }

        private IQueryable<Result> ResultIQueryable;
        public IList<Result> ResultIList;

        public async Task OnGetAsync()
        {

            // Set the message.
            if (TempData["strMessage"] == null)
            {
                TempData["strMessageColor"] = "Green";
                TempData["strMessage"] = "Please choose an option below.";
            }
            else
            {
                MessageColor = TempData["strMessageColor"].ToString();
                Message = TempData["strMessage"].ToString();
            }

            // Define the database query.
            ResultIQueryable = (
                from c in SportsPlayContext.Category
                select new Result
                {
                    Category = c.Category1,
                    CategoryID = c.CategoryID
                });
            // Retrieve the rows for display.
            ResultIList = await ResultIQueryable.ToListAsync();

        }

    }