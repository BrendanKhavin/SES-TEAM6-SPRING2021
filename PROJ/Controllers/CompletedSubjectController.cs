using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PROJ.Models;
using PROJ.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

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

        [HttpPost("addUserSubject")]
        public async Task AddUserSubject(string SubjectId, string UserId, int Score){
            var userSubject = new CompletedSubject() 
            {
                SubjectCode = SubjectId,
                UserId = UserId,
                Score = Score
            };

            await _completedSubjectRepository.InsertOneAsync(userSubject);
        }

        [HttpPost("deleteUserSubject")]
        public async Task DeleteUserSubject(string SubjectId, string UserId){
        
            await _completedSubjectRepository.DeleteManyAsync(userSubject => userSubject.UserId == UserId && userSubject.SubjectCode == SubjectId);
        }
    }
}