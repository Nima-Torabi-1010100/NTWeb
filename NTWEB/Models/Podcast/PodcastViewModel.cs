namespace NTWEB.Models.Podcast
{
    public class PodcastViewModel
    {
        public string Title { get; set; }
        public string Url { get; set; }
        public PodcastViewModel(string title, string url)
        {
            Title = title;
            Url = url;
        }
    }
}