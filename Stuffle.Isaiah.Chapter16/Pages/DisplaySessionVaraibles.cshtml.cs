using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter16.Pages;

[BindProperties]

public class DisplaySessionVaraiblesModel : PageModel
    {
        public string MessageColor;
        public string Message;

        public void OnGet()
        {

        // Get the query string parameters.
        string Shipper = HttpContext.Session.GetString("Shipper");
        string PointOfContact = HttpContext.Session.GetString("PointOfContact");
        string Address = HttpContext.Session.GetString("Address");
        string City = HttpContext.Session.GetString("City");
        string ZipCode = HttpContext.Session.GetString("ZipCode");
        string Phone = HttpContext.Session.GetString("Phone");
        string EmailAddress = HttpContext.Session.GetString("EmailAddress");

        // Set the message.
        MessageColor = "Green";
            Message = "You have saved your information successfully. " +
                "\n Shipper = " + Shipper +
                "\n Point of Contact = " + PointOfContact +
                "\n Address = " + Address +
                "\n City = " + City +
                "\n Zip Code = " + ZipCode +
                "\n Phone = " + Phone +
                "\n Email Address = " + EmailAddress;

        }


    }
