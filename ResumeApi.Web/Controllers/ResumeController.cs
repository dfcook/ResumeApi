namespace ResumeApi.Web.Controllers
{    
    using Microsoft.AspNetCore.Mvc;    
    using ResumeApi.RepositoryInterfaces;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly IResumeRepository _resumeRepository;

        public ResumeController(IResumeRepository resumeRepository)
        {
            _resumeRepository = resumeRepository;
        }

        // GET api/resume/dfcook
        [HttpGet("{userName}")]
        public async Task<IActionResult> Get(string userName)
        {
            var resume = await _resumeRepository.GetResumeByUserNameAsync(userName);
            return SomeOrNotFound(resume);
        }            
    }
}