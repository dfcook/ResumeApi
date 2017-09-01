namespace ResumeApi.Web.Controllers
{    
    using Microsoft.AspNetCore.Mvc;
    using ResumeApi.Model;
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
        
        [HttpGet("{userName}")]
        [ProducesResponseType(200, Type = typeof(Resume))]
        public async Task<IActionResult> Get(string userName)
        {
            var resume = await _resumeRepository.GetResumeByUserNameAsync(userName);
            return SomeOrNotFound(resume);
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(Resume))]
        public async Task<IActionResult> Post([FromBody] Resume resume)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var inserted = await _resumeRepository.InsertResumeAsync(resume);
            return SomeOrNotFound(inserted);
        }

        [HttpDelete("{resumeId}")]
        [ProducesResponseType(200, Type = typeof(Resume))]
        public async Task<IActionResult> Delete(int resumeId)
        {            
            var deleted = await _resumeRepository.DeleteResumeAsync(resumeId);
            return SomeOrNotFound(deleted);
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(Resume))]
        public async Task<IActionResult> Put([FromBody] Resume resume)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var inserted = await _resumeRepository.UpdateResumeAsync(resume);
            return SomeOrNotFound(inserted);
        }
    }
}