using NTWEB.Models.Resume;

namespace NTWEB.Repositories
{
    public interface IResumeRepository
    {
        Task<List<Education>> GetEducationsAsync();
        Task<List<Language>> GetLanguagesAsync();
        Task<List<Skill>> GetSkillsAsync();
        Task<List<WorkExperience>> GetWorkExperiencesAsync();
        Task<ProfileInfo> GetProfileInfoAsync();
    }
}
