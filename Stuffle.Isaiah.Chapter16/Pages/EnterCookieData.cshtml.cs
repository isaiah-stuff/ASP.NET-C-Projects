using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter16.Pages;

[BindProperties]
public class EnterCookieDataModel : PageModel
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
        { }

        public RedirectResult OnPostDisplayShipperQueryStringParameters()
        {
            Response.Cookies.Append("Shipper", Shipper);
            Response.Cookies.Append("Point Of Contact", PointOfContact);
            Response.Cookies.Append("Address", Address);
            Response.Cookies.Append("City", City);
            Response.Cookies.Append("State", State);
            Response.Cookies.Append("Zip Code", ZipCode);
            Response.Cookies.Append("Phone", Phone);
            Response.Cookies.Append("Email Address", EmailAddress);
            // Go to the Welcome page.
            return Redirect("DisplayCookieData");
        }

    }





