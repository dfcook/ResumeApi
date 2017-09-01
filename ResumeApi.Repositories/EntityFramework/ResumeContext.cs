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

            modelBuilder.HasSequence("resume_id_seq");

            modelBuilder.Entity<Resume>()
                .ToTable("resume")
                .HasKey(r => r.Id);

            modelBuilder.Entity<Resume>()
                .Property(r => r.Id)
                .HasDefaultValueSql("nextval('\"resume_id_seq\"')");

            modelBuilder.Entity<KeySkill>()
                .ToTable("key_skill")
                .HasKey(ks => ks.Id);

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.KeySkills)
                .WithOne(ks => ks.Resume)
                .HasForeignKey(ks => ks.ResumeId);

            modelBuilder.Entity<IndustryKnowledge>()
                .ToTable("industry_knowledge")
                .HasKey(ik => ik.Id);

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.IndustryKnowledge)
                .WithOne(ik => ik.Resume)
                .HasForeignKey(ik => ik.ResumeId);

            modelBuilder.Entity<Education>()
                .ToTable("education")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.EducationHistory)
                .WithOne(e => e.Resume)
                .HasForeignKey(e => e.ResumeId);

            modelBuilder.Entity<Experience>()
                .ToTable("experience")
                .HasKey(e => e.Id);

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.CareerExperience)
                .WithOne(ce => ce.Resume)
                .HasForeignKey(ce => ce.ResumeId);

            modelBuilder.Entity<Link>()
                .ToTable("links")
                .HasKey(l => l.Id);

            modelBuilder.Entity<Resume>()
                .HasMany(r => r.Links)
                .WithOne(l => l.Resume)
                .HasForeignKey(l => l.ResumeId);

            base.OnModelCreating(modelBuilder);
        }
    }
}