using Microsoft.EntityFrameworkCore;
using NTWEB.Mappings;
using NTWEB.Models;
namespace NTWEB
{
    public class NTWEBContext : DbContext
    {
        public DbSet<Education> Educations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public NTWEBContext(DbContextOptions dbContext) : base(dbContext)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SkillMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
