namespace ResumeApi.Repositories.EntityFramework
{
    using Microsoft.EntityFrameworkCore;
    using ResumeApi.Model;

    public class ResumeContext : DbContext
    {
        public ResumeContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Resume> Resumes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");

            modelBuilder.Entity<Resume>()
                .ToTable("resume")
                .HasKey(e => e.Id);

            modelBuilder.Entity<KeySkill>()
                .ToTable("key_skill")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.KeySkills)
                .WithOne(ks => ks.Resume)
                .HasForeignKey(ks => ks.ResumeId);

            modelBuilder.Entity<IndustryKnowledge>()
                .ToTable("industry_knowledge")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.IndustryKnowledge)
                .WithOne(ik => ik.Resume)
                .HasForeignKey(ks => ks.ResumeId);

            modelBuilder.Entity<Education>()
                .ToTable("education")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.EducationHistory)
                .WithOne(e => e.Resume)
                .HasForeignKey(ks => ks.ResumeId);

            modelBuilder.Entity<Experience>()
                .ToTable("experience")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.CareerExperience)
                .WithOne(ce => ce.Resume)
                .HasForeignKey(ks => ks.ResumeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}