using LinkVault.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LinkVault.Infrastructure.Configurations
{
    public class ShortUrlConfigurations : IEntityTypeConfiguration<ShortUrl>
    {
        public void Configure(EntityTypeBuilder<ShortUrl> builder)
        {
            builder.ToTable("ShortUrls");
            builder.HasKey(s => s.Id);
            builder.Property(l => l.Id).ValueGeneratedNever();
            builder.Property(s => s.OriginalUrl).HasMaxLength(2024).IsRequired();
            builder.Property(s => s.ShortCode).HasMaxLength(20).IsRequired();
            builder.HasIndex(s => s.ShortCode).IsUnique();
            builder.Property(s => s.CreatedAt).IsRequired();
            builder.Property(s => s.ExpiresAt);
            builder.Property(s => s.IsActive).IsRequired();
            builder.HasMany(s => s.UrlClicks)
                   .WithOne()
                   .HasForeignKey(c => c.ShortUrlId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
