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
        public async Task<List<Education>> GetEducationsAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task<List<Language>> GetLanguagesAsync()
        {
            return await _context.Languages.ToListAsync();
        }

        public async Task<List<Skill>> GetSkillsAsync()
        {
            return await _context.Skills.ToListAsync();
        }
        public async Task<List<WorkExperience>> GetWorkExperiencesAsync()
        {
            return await _context.WorkExperiences.ToListAsync();
        }
    }
}
