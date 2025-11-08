using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTWEB.Models.Service;
using NTWEB.Services;

namespace NTWEB.Pages
{
    public class ServiceModel : PageModel
    {
        private readonly EmailService _emailService;
        private readonly List<string> _projectTypes = new List<string>() { "سایت شخصی", "سایت فروشگاهی", "سایت آموزشی" };
        private readonly List<string> _paymentMethods = new List<string>() { "ریال ایران", "بیت کوین", "تتر" };
        [BindProperty] public ServiceForm ServiceForm { get; set; }
        public SelectList ProjectTypes { get; private set; }
        public SelectList PaymentMethods { get; private set; }
        public ServiceModel(EmailService emailService)
        {
            _emailService = emailService;
        }
        public void OnGet()
        {
            ProjectTypes = new SelectList(_projectTypes);
            PaymentMethods = new SelectList(_paymentMethods);
        }
        public async Task<IActionResult> OnPostAsync()
        {
            ServiceForm.Location = $"{ServiceForm.Country}/{ServiceForm.City}";
            ServiceForm.Message = $"\nProject Type: {ServiceForm.ProjectType}\nCompany Name: {ServiceForm.CompanyName}" +
                    $"\nPhone Number: {ServiceForm.PhoneNumber} \nPayment Method: {ServiceForm.PaymentMethod}" +
                    $"\nLocation: {ServiceForm.Location}";
            ModelState.Remove("ServiceForm.Message");
            ModelState.Remove("ServiceForm.Location");

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
                await _emailService.SendEmailAsync("Service", ServiceForm.Email, ServiceForm.Name, ServiceForm.ProjectName, ServiceForm.Message);
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
