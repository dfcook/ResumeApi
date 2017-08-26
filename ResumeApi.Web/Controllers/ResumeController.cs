namespace ResumeApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using ResumeApi.Model;
    using ResumeApi.RepositoryInterfaces;

    [Route("api/[controller]")]
    public class ResumeController : Controller
    {
        private readonly IResumeRepository _resumeRepository;

        public ResumeController(IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
        }

        // GET api/resume/dfcook
        [HttpGet("{userName}")]
        public Resume Get(string userName)
        {
            return _resumeRepository.GetResumeByUserName(userName);
        }
    }
}