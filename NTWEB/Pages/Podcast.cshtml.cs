using Microsoft.AspNetCore.Mvc.RazorPages;
using NTWEB.Models;
using System.Xml.Linq;

namespace NTWEB.Pages
{
    public class PortfolioModel : PageModel
    {
        private readonly NTWEBContext _context;
        public List<PodcastViewModel> Podcasts { get; set; } = new();
        public PortfolioModel(NTWEBContext context)
        {
            _context = context;
        }
        public async Task OnGetAsync()
        {
            try
            {
                using var client = new HttpClient();
                var response = await client.GetStringAsync("http://rss.castbox.fm/everest/ca986f01c17d4c0e835db282abb4a23b.xml");
                var xml = XDocument.Parse(response);

                if (xml.Root == null)
                    throw new Exception("Invalid RSS XML: Missing root.");
                XNamespace castboxNamespace = xml.Root?.Attribute(XName.Get("castbox", "http://www.w3.org/2000/xmlns/"))?.Value ?? "http://castbox.fm/dtds/podcast-1.0.dtd";
                XNamespace itunesNamespace = xml.Root?.Attribute(XName.Get("itunes", "http://www.w3.org/2000/xmlns/"))?.Value ?? "http://www.itunes.com/dtds/podcast-1.0.dtd";

                var castboxUrl = "https://castbox.fm/episode/";

                var castboxPid = xml.Element("rss")?.Element("channel")?.Element(castboxNamespace + "pid")?.Value ?? "Unknown PID";

                Podcasts = xml.Descendants("item")
                    .Where(item => item.Element("description")?.Value.Contains("نیما ترابی") == true)
                    .Select(item => new PodcastViewModel(item.Element("title")?.Value ?? "Unknown Title", castboxUrl + (item.Element("title")?.Value ?? "") + "-id" + castboxPid + "-id"
                        + (item.Element(castboxNamespace + "tid")?.Value ?? "Unknown Url"))).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Podcasts = new List<PodcastViewModel> { new PodcastViewModel("خطا در دریافت پادکست‌ها", "#") };
            }
        }
    }
}
