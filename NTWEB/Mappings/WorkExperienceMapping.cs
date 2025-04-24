using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTWEB.Models;

namespace NTWEB.Mappings
{
    public class WorkExperienceMapping : IEntityTypeConfiguration<WorkExperience>
    {
        public void Configure(EntityTypeBuilder<WorkExperience> builder)
        {
            builder.ToTable("WorkExperiences");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.JobTitle).IsRequired().HasMaxLength(50);
            builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Year).IsRequired().HasMaxLength(30);
        }
    }
}
