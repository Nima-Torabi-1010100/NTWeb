using NTWEB._01_Framework;
using System.Text.RegularExpressions;

namespace NTWEB.Models
{
    public class Podcast : EntityBase
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public Podcast(string title, string url)
        {
            Title = title;
            Url = url;
        }
        public Podcast()
        {
        }
    }
}