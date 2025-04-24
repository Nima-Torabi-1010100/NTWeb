using Microsoft.AspNetCore.Mvc.RazorPages;

namespace NTWEB.Pages
{
    public class PortfolioModel : PageModel
    {
        private readonly NTWEBContext _context;
        public PortfolioModel(NTWEBContext context)
        {
            _context = context;
        }
        public void OnGet()
        {
        }
    }
}
