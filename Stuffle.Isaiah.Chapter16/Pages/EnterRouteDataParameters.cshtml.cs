using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter16.Pages;
[BindProperties]
     
public class EnterRouteDataParametersModel : PageModel
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
    public void OnGet(){}

    public RedirectToPageResult OnPostLogIn()
    {
        return RedirectToPage("WelcomeRouteDataParameters",
               new
               {
                   Shipper = Shipper,
                   PointOfContact = PointOfContact,
                   Address = Address,
                   City = City,
                   State = State,
                   ZipCode = ZipCode,
                   Phone = Phone,
                   EmailAddress = EmailAddress
               });
    }
       
}

