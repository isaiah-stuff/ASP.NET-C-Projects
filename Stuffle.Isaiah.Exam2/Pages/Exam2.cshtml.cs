using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Stuffle.Isaiah.Exam2.Services;
using System.Net.Mail;

namespace Stuffle.Isaiah.Exam2.Pages;

[BindProperties]
    public class Exam2Model : PageModel
    {
        private readonly IEmailService IEmailService;

        //instructor method
        public Exam2Model(IEmailService IES)
        {
            IEmailService = IES;
        }

        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public void OnGet()
            {
            }

        public async Task OnPostSubmit()
        {

            // Send the email.
            await IEmailService.SendEmail(From, To, Subject, Message);
            // Redirect to the same page to clear the form.
            RedirectToPage();
        }
    }
