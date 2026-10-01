using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Stuffle.Isaiah.Chapter16.Pages;

[BindProperties]
public class EnterSessionVariablesModel : PageModel
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

        public RedirectResult OnPostDisplayShipperQueryStringParameters()
        {
            HttpContext.Session.Clear();

            HttpContext.Session.SetString("Shipper", Shipper);
            HttpContext.Session.SetString("PointOfContact", PointOfContact);
            HttpContext.Session.SetString("Address", Address);
            HttpContext.Session.SetString("City", City);
            HttpContext.Session.SetString("State", State);
            HttpContext.Session.SetString("ZipCode", ZipCode);
            HttpContext.Session.SetString("Phone", Phone);
            HttpContext.Session.SetString("EmailAddress", EmailAddress);
            // Go to the Welcome page.
            return Redirect("DisplaySessionVaraibles");
        }

    }




