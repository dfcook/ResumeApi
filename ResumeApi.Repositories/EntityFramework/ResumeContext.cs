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
                .ToTable("resume");

            modelBuilder.Entity<KeySkill>()
                .ToTable("key_skill");

            modelBuilder.Entity<IndustryKnowledge>()
                .ToTable("industry_knowledge");

            modelBuilder.Entity<Education>()
                .ToTable("education");

            base.OnModelCreating(modelBuilder);
        }
    }
}