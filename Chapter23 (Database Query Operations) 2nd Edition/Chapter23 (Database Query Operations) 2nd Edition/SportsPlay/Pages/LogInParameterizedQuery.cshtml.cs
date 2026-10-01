using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportsPlay.Models;

namespace SportsPlay.Pages;

[BindProperties]
public class LogInParameterizedQueryModel : PageModel
{

    private readonly SportsPlayContext SportsPlayContext;
    public LogInParameterizedQueryModel(SportsPlayContext SPC)
    {
        SportsPlayContext = SPC;
    }

    public string MessageColor;
    public string Message;

    public string EmailAddress { get; set; }
    public string Password { get; set; }

    private Employee Employee;

    public void OnGet()
    {
    }

    public async Task OnPostLogIn()
    {

        // Log in the user.
        Employee = await SportsPlayContext.Employee
            .Where(e => e.EmailAddress == EmailAddress && e.Password == Password)
            .AsNoTracking() //don't track the data because we are not making any changes
            .FirstOrDefaultAsync(); //find the first email and password combination that matches

        if (Employee != null)
        {
            // Set the message.
            string strUser = Employee.FirstName + " " + Employee.MiddleInitial + " " + Employee.LastName;
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