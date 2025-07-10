using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTWEB.Models.Resume;

namespace NTWEB.Mappings
{
    public class EducationMapping : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.ToTable("Educations");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Degree).IsRequired().HasMaxLength(50);
            builder.Property(x => x.School).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Year).IsRequired().HasMaxLength(30);
        }
    }
}
