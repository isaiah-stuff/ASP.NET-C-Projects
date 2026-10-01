using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter16.Pages;

[BindProperties]
public class EnterTempDataVariablesModel : PageModel
{
    public string MessageColor;
    public string Message;

    public string Shipper { get; set; }
    public string PointOfContact { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Phone { get; set; }
    public string EmailAddress { get; set; }

    public void OnGet()
    {
    }

    public RedirectResult OnPostLogIn()
    {
        TempData["Shipper"] = Shipper;
        TempData["PointOfContact"] = PointOfContact;
        TempData["Address"] = Address;
        TempData["City"] = City;
        TempData["State"] = State;
        TempData["ZipCode"] = ZipCode;
        TempData["Phone"] = Phone;
        TempData["EmailAddress"] = EmailAddress;
        return Redirect("/WelcomeTempDataVariables");
    }
}






