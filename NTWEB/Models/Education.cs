using NTWEB._01_Framework;

namespace NTWEB.Models
{
    public class Education : EntityBase
    {
        public string Degree { get; private set; }
        public string School { get; private set; }
        public string Year { get; private set; }
        public Education(string degree, string school, string year)
        {
            Degree = degree;
            School = school;
            Year = year;
        }
    }
}
