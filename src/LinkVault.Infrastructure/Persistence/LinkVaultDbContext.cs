using LinkVault.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinkVault.Infrastructure.Persistence
{
    public class LinkVaultDbContext : DbContext
    {
        public LinkVaultDbContext(DbContextOptions<LinkVaultDbContext> options) : base(options)
        {
        }
        public DbSet<ShortUrl> ShortUrls { get; set; }
        public DbSet<UrlClick> UrlClicks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LinkVaultDbContext).Assembly);

        }

    }
}
