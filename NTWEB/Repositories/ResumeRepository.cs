using Microsoft.EntityFrameworkCore;
using NTWEB.Models.Resume;

namespace NTWEB.Repositories
{
    public class ResumeRepository : IResumeRepository
    {
        private readonly NTWEBContext _context;
        public ResumeRepository(NTWEBContext context)
        {
            _context = context;
        }
        public Task<List<Education>> GetEducationsAsync()
        {
            return _context.Educations.AsNoTracking().ToListAsync();
        }

        public Task<List<Language>> GetLanguagesAsync()
        {
            return _context.Languages.AsNoTracking().ToListAsync();
        }

        public Task<List<Skill>> GetSkillsAsync()
        {
            return _context.Skills.AsNoTracking().ToListAsync();
        }
        public Task<List<WorkExperience>> GetWorkExperiencesAsync()
        {
            return _context.WorkExperiences.AsNoTracking().ToListAsync();
        }
    }
}
