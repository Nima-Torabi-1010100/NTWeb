using NTWEB._01_Framework;

namespace NTWEB.Models.Resume
{
    public class WorkExperience : EntityBase
    {
        public string JobTitle { get; private set; }
        public string CompanyName { get; private set; }
        public string Description { get; private set; }
        public string Year { get; private set; }
        public WorkExperience(string jobTitle, string companyName, string description, string year)
        {
            JobTitle = jobTitle;
            CompanyName = companyName;
            Description = description;
            Year = year;
        }
    }
}
