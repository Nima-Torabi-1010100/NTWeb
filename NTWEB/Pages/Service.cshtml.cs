using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NTWEB.Models.Service;

namespace NTWEB.Pages
{
    public class ServiceModel : PageModel
    {
        [BindProperty] public ServiceForm ServiceForm { get; set; }
        public void OnGet()
        {
        }
    }
}
