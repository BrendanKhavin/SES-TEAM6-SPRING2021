using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PROJ.Models;
using PROJ.Services;
using Microsoft.AspNetCore.Authorization;

namespace PROJ.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class SubjectsController : ControllerBase
    {
        private IMongoRepository<Subject>  _subjectsRepository;
        private RecommendService recommendService;

        public SubjectsController(IMongoRepository<Subject> subjectsRepository)
        {
            _subjectsRepository = subjectsRepository;
            this.recommendService = new RecommendService();
        }

        [HttpGet]
        public IEnumerable<Subject> GetSubjects() =>
            _subjectsRepository.FindAll().ToList();

        // route is: api/subjects/{subjectCode}
        [HttpGet("{code}")]
        public Subject GetSubjectByCode(string code) =>
            _subjectsRepository.FindOne(s => s.subjectCode == code);
            

        [HttpGet("recommend/{userId}")]
        public IEnumerable<Subject> GetRecommendations(string userId) 
        {
          string[] recommendedSubjectCodes = recommendService.GetRecommendation(userId); 
          List<Subject> recommendedSubjects = new List<Subject>();
          foreach (string code in recommendedSubjectCodes) {
            Subject s = _subjectsRepository.FindOne(subject => subject.subjectCode.Equals(code));
            recommendedSubjects.Add(s);
          }

          return recommendedSubjects;
        }

    //     [HttpPost("addSubject")]
    //     public async Task AddSubject(String code, String name){
    //         var subject = new Subject() 
    //         {
    //             subjectCode = code,
    //             subjectName = name
    //         };

    //         await _subjectsRepository.InsertOneAsync(subject);
    //     }
    }


}
