using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using MailKit.Net.Smtp;
using NTWEB._01_Framework;
using NTWEB.Models.Contact;
using NTWEB.Services;

namespace NTWEB.Pages
{
    public class ContactModel : PageModel
    {
        private readonly EmailService _emailService;
        [BindProperty] public ContactForm ContactForm { get; set; }
        [TempData]
        public string OperationMessage { get; set; }
        [TempData]
        public string OperationStatus { get; set; }
        public ContactModel(EmailService emailService)
        {
            _emailService = emailService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (TempData["LastEmailSent"] is DateTime last &&
                DateTime.Now - last < TimeSpan.FromSeconds(60))
            {
                OperationMessage = $"لطفا کمی بعد دوباره تلاش کنید!";
                OperationStatus = "failure";
                return RedirectToPage();
            }

            if (!ModelState.IsValid)
                return Page();
            try
            {
                await _emailService.SendEmailAsync("Contact", ContactForm.Email, ContactForm.Name, ContactForm.Subject, ContactForm.Message);
                TempData["LastEmailSent"] = DateTime.Now;

                OperationMessage = ApplicationMessages.SuccessMessage;
                OperationStatus = "success";
                return RedirectToPage();
            }
            catch
            {
                OperationMessage = ApplicationMessages.FailureMessage;
                OperationStatus = "failure";
                return RedirectToPage();
            }
        }
    }
}
