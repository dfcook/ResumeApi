namespace ResumeApi.Repositories
{    
    using Microsoft.EntityFrameworkCore;
    using ResumeApi.Model;
    using ResumeApi.Repositories.EntityFramework;
    using ResumeApi.RepositoryInterfaces;
    using System.Threading.Tasks;
    using ResumeApi.Common;
    
    public class ResumeRepository : IResumeRepository
    {
        private ResumeContext _context;

        public ResumeRepository(ResumeContext context)
        {
            _context = context;
        }

        public async Task<Maybe<Resume>> DeleteResumeAsync(int resumeId)
        {
            var resume = await _context.Resumes.FindAsync(resumeId);
            if (resume == null)
            {
                return Maybe.None<Resume>();
            }

            _context.Resumes.Remove(resume);
            await _context.SaveChangesAsync();

            return resume.ToMaybe();
        }

        public Task<Maybe<Resume>> GetResumeByUserNameAsync(string userName) =>
            _context.Resumes
                .Include(r => r.KeySkills)
                .Include(r => r.IndustryKnowledge)
                .Include(r => r.CareerExperience)
                .Include(r => r.EducationHistory)
                .Include(r => r.Links)
                .SingleOrDefaultAsync(r => r.UserName == userName)
                .ContinueWith(resume => resume.Result.ToMaybe());        

        public async Task<Maybe<Resume>> InsertResumeAsync(Resume resume)
        {
            _context.Resumes.Add(resume);
            await _context.SaveChangesAsync();

            return await GetResumeByUserNameAsync(resume.UserName);
        }

        private async Task<bool> ResumeExists(int resumeId) =>
            await _context.Resumes.AnyAsync(r => r.Id == resumeId);        

        public async Task<Maybe<Resume>> UpdateResumeAsync(Resume resume)
        {
            var exists = await ResumeExists(resume.Id);
            if (!exists)
            {
                return Maybe.None<Resume>();
            }

            _context.Entry(resume).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return resume.ToMaybe();
        }
    }
}