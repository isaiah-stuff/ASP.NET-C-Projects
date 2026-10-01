using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter16.Pages;

[BindProperties]
public class WelcomeTempDataVariablesModel : PageModel
{ 
    public string MessageColor;
    public string Message;

    public void OnGet()
    {

        string Shipper = TempData["Shipper"].ToString();
        string PointOfContact = TempData["PointOfContact"].ToString();
        string Address = TempData["Address"].ToString();
        string City = TempData["City"].ToString();
        string State = TempData["State"].ToString();
        string ZipCode = TempData["ZipCode"].ToString();
        string Phone = TempData["Phone"].ToString();
        string EmailAddress = TempData["EmailAddress"].ToString();

        MessageColor = "Green";
        Message = $"You have saved your information successfully.Shipper =  {Shipper}, Point of Contact =   {PointOfContact}, Address =   {Address}, City =   {City}, Zip Code =   {ZipCode}, Phone =   {Phone}, Email Address =   {EmailAddress}";


    }


}

