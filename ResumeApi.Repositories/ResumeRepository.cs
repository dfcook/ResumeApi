namespace ResumeApi.Repositories
{
    using System;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using ResumeApi.Model;
    using ResumeApi.Repositories.EntityFramework;
    using ResumeApi.RepositoryInterfaces;

    public class ResumeRepository : IResumeRepository
    {
        private ResumeContext _context;

        public ResumeRepository(ResumeContext context)
        {
            _context = context;
        }

        public Resume GetResumeByUserName(string userName)
        {
            return _context.Resumes
                .Include(r => r.KeySkills)
                .Include(r => r.IndustryKnowledge)
                .Include(r => r.CareerExperience)
                .Include(r => r.EducationHistory)
                .SingleOrDefault(r => r.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }
    }
}