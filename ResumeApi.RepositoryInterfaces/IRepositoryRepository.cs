namespace ResumeApi.RepositoryInterfaces
{
    using ResumeApi.Model;
    using System.Threading.Tasks;

    public interface IResumeRepository
    {
        Task<Maybe<Resume>> GetResumeByUserNameAsync(string userName);
    }
}