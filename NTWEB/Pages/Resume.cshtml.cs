using Microsoft.AspNetCore.Mvc.RazorPages;
using NTWEB.Models;

namespace NTWEB.Pages
{
    public class ResumeModel : PageModel
    {
        private readonly IConfiguration _configuration;
        private readonly NTWEBContext _context;
        public List<Skill> Skills { get; private set; }
        public ProfileInfo ProfileInfo { get; private set; }
        public List<Skill> LocalSkills { get; private set; }
        public List<Language> Languages { get; private set; }
        public Education Education { get; private set; }
        public List<WorkExperience> Experiences { get; private set; }
        public ResumeModel(NTWEBContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;

            Skills = new List<Skill>();
            LocalSkills = new List<Skill>()
            {
                new Skill("HTML",100),
                new Skill("CSS",20),
                new Skill("#C",70),
                new Skill("ASP .NET",50),
                new Skill("Git",20),
                new Skill("Problem-solving",100)
            };
            Languages = new List<Language>()
            {
                new Language("ترکی","زبان مادری"),
                new Language("فارسی","عالی"),
                new Language("انگلیسی","متوسط")
            };
            Education = new Education("کارشناسی چند رسانه ای", "دانشگاه هنر تبریز", "از سال ۱۴۰۱ تاکنون");
            Experiences = new List<WorkExperience>()
            {
                new WorkExperience("پادکست ادیتور","<a href=\"https://13mag.ir/\">مجله سیزده</a>","تدوینگر چندین پادکست در مجله سیزده بودم که میتونید از طریق پادگیرهای مختلف بشنوید و لذت ببرید.","از سال ۱۴۰۰ تاکنون")
            };
        }
        public void OnGet()
        {
            ProfileInfo = _configuration.GetSection("ProfileInfo").Get<ProfileInfo>();
            ProfileInfo = new ProfileInfo
            {
                FullName = _configuration["FullName"],
                BirthDate = _configuration["BirthDate"],
                MobileNumber = _configuration["MobileNumber"],
                Location = _configuration["Location"],
                MilitaryStatus = _configuration["MilitaryStatus"],
                Email = _configuration["Email"]
            };
            //Skills = _context.Skills.ToList();
        }
    }
}
