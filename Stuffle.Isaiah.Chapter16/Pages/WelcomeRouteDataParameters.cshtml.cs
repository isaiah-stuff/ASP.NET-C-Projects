using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter16.Pages;

[BindProperties]
    public class WelcomeRouteDataParametersModel : PageModel
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
        public void OnGet(string Shipper, string PointOfContact, string Address,
            string City, string State, string ZipCode, string Phone, string EmailAddress)
        {

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
