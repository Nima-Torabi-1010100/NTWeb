using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NTWEB.Models.Contact;
using NTWEB.Services;

namespace NTWEB.Pages
{
    public class ContactModel : PageModel
    {
        private readonly EmailService _emailService;
        [BindProperty] public ContactForm ContactForm { get; set; }
        public ContactModel(EmailService emailService)
        {
            _emailService = emailService;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return new JsonResult(new { success = false, message = $"❌ ارسال پیام با خطا مواجه شد" });

            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("LastEmailSent"))
                && DateTime.Parse(HttpContext.Session.GetString("LastEmailSent")) is DateTime last
                && DateTime.Now - last < TimeSpan.FromSeconds(60))
            {
                return new JsonResult(new { success = false, message = $"❌ {(int)(60 - (DateTime.Now - last).TotalSeconds)} ثانیه بعد دوباره امتحان کنید" });
            }

            try
            {
                await _emailService.SendEmailAsync("Contact", ContactForm.Email, ContactForm.Name, ContactForm.Subject, ContactForm.Message);
                HttpContext.Session.SetString("LastEmailSent", DateTime.Now.ToString());
                return new JsonResult(new { success = true });
            }

            catch
            {
                return new JsonResult(new { success = false, message = "ارسال پیام با خطا مواجه شد ❌" });
            }
        }
    }
}
