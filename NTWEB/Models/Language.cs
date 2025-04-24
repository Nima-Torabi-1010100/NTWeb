using NTWEB._01_Framework;

namespace NTWEB.Models
{
    public class Language : EntityBase
    {
        public string Title { get; private set; }
        public string Level { get; private set; }
        public Language(string title, string level)
        {
            Title = title;
            Level = level;
        }
    }
}
