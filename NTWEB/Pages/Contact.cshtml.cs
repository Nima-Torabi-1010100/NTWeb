using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit;
using MailKit.Net.Smtp;
using NTWEB._01_Framework;
using NTWEB.Models.Contact;

namespace NTWEB.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty] public ContactForm ContactForm { get; set; }
        [TempData]
        public string OperationMessage { get; set; }
        [TempData]
        public string OperationStatus { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var email = new MimeMessage();
                    email.From.Add(new MailboxAddress("NTWEB", Variables.Email));
                    email.To.Add(MailboxAddress.Parse(Variables.Email));
                    email.ReplyTo.Add(new MailboxAddress(ContactForm.Name, ContactForm.Email));
                    email.Subject = ContactForm.Subject;

                    email.Body = new TextPart("plain")
                    {
                        Text = $"From: {ContactForm.Name}\nEmail: {ContactForm.Email}\n\nMessage: {ContactForm.Message}"
                    };
                    var client = new SmtpClient();
                    await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
                    await client.AuthenticateAsync(Variables.Email, Variables.AppPassword);
                    await client.SendAsync(email);

                    ContactForm = new ContactForm();

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
            return Page();
        }
    }
}
