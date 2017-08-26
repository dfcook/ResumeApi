namespace ResumeApi.RepositoryInterfaces
{
    using ResumeApi.Model;

    public interface IResumeRepository
    {
        Resume GetResumeByUserName(string userName);
    }
}