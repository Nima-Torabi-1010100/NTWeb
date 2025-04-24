using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTWEB.Models;

namespace NTWEB.Mappings
{
    public class PodcastMapping : IEntityTypeConfiguration<Podcast>
    {
        public void Configure(EntityTypeBuilder<Podcast> builder)
        {
            builder.ToTable("Portfolios");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ImageAlt).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(255);
        }
    }
}
