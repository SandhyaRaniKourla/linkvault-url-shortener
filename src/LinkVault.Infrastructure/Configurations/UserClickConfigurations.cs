using LinkVault.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkVault.Infrastructure.Configurations
{
    public class UserClickConfigurations : IEntityTypeConfiguration<UrlClick>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<UrlClick> builder)
        {
            builder.ToTable("UrlClicks");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedNever();
            builder.Property(c => c.ShortUrlId).IsRequired();
            builder.Property(c => c.ClickedAt).IsRequired();
            builder.Property(c => c.UserAgent).HasMaxLength(512);
            builder.Property(c => c.Referrer).HasMaxLength(1024);
            builder.HasIndex(c => c.ShortUrlId);
            builder.HasIndex(c => c.ClickedAt);
        }  
    }
}
