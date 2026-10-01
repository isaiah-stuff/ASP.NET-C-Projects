using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Mail;

namespace Stuffle.Isaiah.Chapter16.Pages;
[BindProperties]
public class DisplayShipperQueryStringParametersModel : PageModel
{
    public string MessageColor;
    public string Message;

    public void OnGet()
    {

        // Get the query string parameters.
        string Shipper = Request.Query["Shipper"];
        string PointOfContact = Request.Query["Point of Contact"];
        string Address = Request.Query["Address"];
        string City = Request.Query["City"];
        string ZipCode = Request.Query["ZipCode"];
        string Phone = Request.Query["Phone"];
        string EmailAddress = Request.Query["EmailAddress"];
        // Set the message.
        MessageColor = "Green";
        Message = "You have saved your information successfully. " + 
            "\n Shipper = " +Shipper + 
            "\n Point of Contact = " + PointOfContact + 
            "\n Address = " + Address +
            "\n City = " + City +
            "\n Zip Code = " + ZipCode +
            "\n Phone = "+ Phone +
            "\n Email Address = " + EmailAddress;

    }


}

