using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages;

[BindProperties]
public class LogInStoredProcedureQueryModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public LogInStoredProcedureQueryModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public string MessageColor;
    public string Message;

    public string EmailAddress { get; set; }
    public string Password { get; set; }

    private IQueryable<Employee> EmployeeIQueryable;
    private IList<Employee> EmployeeIList;

    public void OnGet()
    {
    }

    public async Task OnPostLogIn()
    {

        // Log in the user.
        EmployeeIQueryable = SportsPlayContext.Employee
            .FromSqlRaw("EXECUTE EmployeeLogin {0}, {1}", EmailAddress, Password);
        EmployeeIList = await EmployeeIQueryable.ToListAsync();

        if (EmployeeIList.Count > 0)
        {
            // Set the message.
            string strUser = EmployeeIList[0].FirstName + " " + EmployeeIList[0].MiddleInitial + " " + EmployeeIList[0].LastName;
            MessageColor = "Green";
            Message = "You have logged in successfully as " + strUser + "! Welcome to SportsPlay!";
        }
        else
        {
            // Set the message.
            MessageColor = "Red";
            Message = "You have entered an invalid email address and password combination. Please try again.";
        }

    }

}