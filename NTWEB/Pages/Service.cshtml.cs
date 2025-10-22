using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NTWEB._01_Framework;
using NTWEB.Models.Service;
using NTWEB.Services;

namespace NTWEB.Pages
{
    public class ServiceModel : PageModel
    {
        private readonly EmailService _emailService;
        private readonly List<string> _projectTypes = new List<string>() { "طراحی سایت" };
        private readonly List<string> _paymentMethods = new List<string>() { "ریال ایران", "بیت کوین", "تتر" };
        [BindProperty] public ServiceForm ServiceForm { get; set; }
        [TempData]
        public string OperationMessage { get; set; }
        [TempData]
        public string OperationStatus { get; set; }
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
            if (TempData["LastEmailSent"] is DateTime last &&
                DateTime.Now - last < TimeSpan.FromSeconds(15))
            {
                OperationMessage = $"لطفا کمی بعد دوباره تلاش کنید!";
                OperationStatus = "failure";
                return RedirectToPage();
            }
            ServiceForm.Location = $"{ServiceForm.Country}/{ServiceForm.City}";
            ServiceForm.Message = $"\nProject Type: {ServiceForm.ProjectType}\nCompany Name: {ServiceForm.CompanyName}" +
                    $"\nPhone Number: {ServiceForm.PhoneNumber} \nPayment Method: {ServiceForm.PaymentMethod}" +
                    $"\nLocation: {ServiceForm.Location}";
            ModelState.Remove("ServiceForm.Message");
            ModelState.Remove("ServiceForm.Location");

            if (!ModelState.IsValid)
                return Page();
            try
            {
                await _emailService.SendEmailAsync("Service", ServiceForm.Email, ServiceForm.Name, ServiceForm.ProjectName, ServiceForm.Message);
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
