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
        private RecommendService recommendService;

        public SubjectsController(ISubjectRepository subjectRepository)
        {
            this.subjectRepository = subjectRepository;
            this.recommendService = new RecommendService();
        }

        [HttpGet]
        public List<Subject> GetSubjects() =>
            subjectRepository.GetSubjects().ToList();

        // route is: api/subjects/{subjectCode}
        [HttpGet("{code}")]
        public Subject GetSubjectByCode(string code) =>
            subjectRepository.GetSubjectByCode(code);

        [HttpGet("recommend/{userId}")]
        public List<Subject> GetRecommendations(string userId) 
        {
          string[] recommendedSubjectCodes = recommendService.GetRecommendation(userId); 
          List<Subject> recommendedSubjects = new List<Subject>();
          foreach (string subjectCode in recommendedSubjectCodes) {
            Subject s = subjectRepository.GetSubjectByCode(subjectCode);
            recommendedSubjects.Add(s);
          }

          return recommendedSubjects;
        }
    }


}
