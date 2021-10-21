using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PROJ.Models;
using PROJ.Services;
using Microsoft.AspNetCore.Authorization;

namespace PROJ.Controllers
{
    [Route("api/[controller]")]
    public class CompletedSubjectsController : ControllerBase
    {
        private IMongoRepository<CompletedSubject>  _completedSubjectRepository;

        public CompletedSubjectsController(IMongoRepository<CompletedSubject> completedSubjectRepository)
        {
            _completedSubjectRepository = completedSubjectRepository;
        }


        [HttpGet]
        public IEnumerable<CompletedSubject> GetCompletedSubjects() =>
            _completedSubjectRepository.FindAll();

        [HttpGet("user/{UserId}")]
        public IEnumerable<CompletedSubject> GetCompletedSubjectsByUserId(string userId) =>
          _completedSubjectRepository.FilterBy(s => s.UserId == userId);

        [HttpGet("subject/{SubjectId}")]
        public IEnumerable<CompletedSubject> GetCompletedSubjectsBySubjectId(string subjectId) =>
          _completedSubjectRepository.FilterBy(s => s.SubjectCode == subjectId);
    }
}