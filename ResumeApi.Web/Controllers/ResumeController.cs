using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResumeApi.Model;
using ResumeApi.RepositoryInterfaces;

namespace ResumeApi.Controllers
{
    [Route("api/[controller]")]
    public class ResumeController : Controller
    {
        private readonly IResumeRepository _resumeRepository;

        public ResumeController(IResumeRepository resumeRepository)
        {
            this._resumeRepository = resumeRepository;
        }

        // GET api/resume/dfcook
        [HttpGet("{userName}")]
        public Resume Get(string userName)
        {
            return _resumeRepository.GetResumeByUserName(userName);
        }
    }
}