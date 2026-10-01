using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter16.Pages;
[BindProperties]
public class DisplayCookieDataModel : PageModel
    {
        public string MessageColor;
        public string Message;

        public void OnGet()
        {

            // Get the query string parameters.
            string Shipper = Request.Cookies["strUser"];
        string PointOfContact = Request.Cookies["strUser"];
        string Address = Request.Cookies["strUser"];
        string City = Request.Cookies["strUser"];
        string ZipCode = Request.Cookies["strUser"];
        string Phone = Request.Cookies["strUser"];
        string EmailAddress = Request.Cookies["strUser"];
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
