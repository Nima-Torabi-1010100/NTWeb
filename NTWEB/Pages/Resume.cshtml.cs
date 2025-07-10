using Microsoft.AspNetCore.Mvc.RazorPages;
using NTWEB.Models.Resume;
using NTWEB.Repositories;

namespace NTWEB.Pages
{
    public class ResumeModel : PageModel
    {
        private readonly IResumeRepository _resumeRepository;
        public List<Skill> Skills { get; private set; }
        public ProfileInfo ProfileInfo { get; private set; }
        public List<Language> Languages { get; private set; }
        public List<Education> Educations { get; private set; }
        public List<WorkExperience> Experiences { get; private set; }
        public ResumeModel(IResumeRepository repository)
        {
            _resumeRepository = repository;
        }
        public async Task OnGetAsync()
        {
            Educations = await _resumeRepository.GetEducationsAsync() ?? new List<Education>();
            Languages = await _resumeRepository.GetLanguagesAsync() ?? new List<Language>();
            Skills = await _resumeRepository.GetSkillsAsync() ?? new List<Skill>();
            Experiences = await _resumeRepository.GetWorkExperiencesAsync() ?? new List<WorkExperience>();
            ProfileInfo = await _resumeRepository.GetProfileInfoAsync();
        }
    }
}
