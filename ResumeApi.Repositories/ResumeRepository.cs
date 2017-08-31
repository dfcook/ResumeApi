namespace ResumeApi.Repositories
{
    using System;    
    using Microsoft.EntityFrameworkCore;
    using ResumeApi.Model;
    using ResumeApi.Repositories.EntityFramework;
    using ResumeApi.RepositoryInterfaces;
    using System.Threading.Tasks;

    public class ResumeRepository : IResumeRepository
    {
        private ResumeContext _context;

        public ResumeRepository(ResumeContext context)
        {
            _context = context;
        }

        public Task<Maybe<Resume>> GetResumeByUserNameAsync(string userName)
        {
            return _context.Resumes
                .Include(r => r.KeySkills)
                .Include(r => r.IndustryKnowledge)
                .Include(r => r.CareerExperience)
                .Include(r => r.EducationHistory)
                .SingleOrDefaultAsync(r => r.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
                .ContinueWith(resume => resume.Result.ToMaybe());
        }
    }
}