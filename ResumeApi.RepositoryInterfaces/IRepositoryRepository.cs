namespace ResumeApi.RepositoryInterfaces
{
    using ResumeApi.Common;
    using ResumeApi.Model;
    using System.Threading.Tasks;

    public interface IResumeRepository
    {
        Task<Maybe<Resume>> GetResumeByUserNameAsync(string userName);

        Task<Maybe<Resume>> InsertResumeAsync(Resume resume);

        Task<Maybe<Resume>> DeleteResumeAsync(int resumeId);

        Task<Maybe<Resume>> UpdateResumeAsync(Resume resume);
    }
}