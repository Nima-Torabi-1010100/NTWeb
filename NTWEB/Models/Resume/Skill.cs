using NTWEB._01_Framework;

namespace NTWEB.Models.Resume
{
    public class Skill : EntityBase
    {
        public string Title { get; private set; }
        public int Progress { get; private set; }
        public Skill(string title, int progress)
        {
            Title = title;
            Progress = progress;
        }
    }
}
