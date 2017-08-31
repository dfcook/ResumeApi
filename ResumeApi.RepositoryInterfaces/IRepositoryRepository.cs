namespace ResumeApi.RepositoryInterfaces
{
    using ResumeApi.Common;
    using ResumeApi.Model;
    using System.Threading.Tasks;

    public interface IResumeRepository
    {
        Task<Maybe<Resume>> GetResumeByUserNameAsync(string userName);
    }
}