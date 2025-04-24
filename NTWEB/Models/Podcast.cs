using NTWEB._01_Framework;
using System.Text.RegularExpressions;

namespace NTWEB.Models
{
    public class Podcast : EntityBase
    {
        public string Title { get; private set; }
        public string Slug { get; private set; }
        public string Image { get; private set; }
        public string ImageAlt { get; private set; }
        public string ShortDescription { get; private set; }
        public Podcast(string title, string image, string imageAlt, string shortDescription)
        {
            Title = title;
            Image = image;
            ImageAlt = imageAlt;
            ShortDescription = shortDescription;
            Slug = GenerateSlug();
        }
        public string GenerateSlug()
        {
            if (!string.IsNullOrWhiteSpace(Title))
                return "";
            string slug = Title.ToLower();
            slug = Regex.Replace(slug, @"[^a-z0-9\s]", "");
            slug = Regex.Replace(slug, @"\s+", "-");
            return slug;
        }
    }
}