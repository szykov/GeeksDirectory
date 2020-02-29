﻿#nullable disable

using GeeksDirectory.Domain.Entities;
using GeeksDirectory.Infrastructure.Seed;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GeeksDirectory.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<GeekProfile> Profiles { get; set; }

        public virtual DbSet<Skill> Skills { get; set; }

        public virtual DbSet<Assessment> Assessments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder.Seed();
        }
    }
}
