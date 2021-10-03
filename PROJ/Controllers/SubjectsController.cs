using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROJ.Interface;
using PROJ.Models;
using PROJ.Repository;
using PROJ.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PROJ.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    public class SubjectsController : Controller
    {

        private ISubjectRepository  subjectRepository;
        // private RecommendService recommendService = new RecommendService();

        public SubjectsController(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
        }

        [HttpGet]
        public List<Subject> GetSubjects() =>
            subjectRepository.GetSubjects().ToList();

        // route is: api/subjects/{subjectCode}
        [HttpGet("{code}")]
        public Subject GetSubjectByCode(string code) =>
            // recommendService.GetRecommendations();
            subjectRepository.GetSubjectByCode(code);

    }
}
