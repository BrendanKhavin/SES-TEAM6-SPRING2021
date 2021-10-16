using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJ.Interface;
using PROJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class SubjectController : Controller
    {
  

        public ICompletedSubjectsRepository completedSubjectsRepository { get; set; }

        
        public SubjectController(ICompletedSubjectsRepository completedSubjectsRepository){
            this.completedSubjectsRepository = completedSubjectsRepository; 
        }

        [HttpPost("addcompletedsubject")]
        public void AddCompletedSubject(CompletedSubjects completedSubjects){
            completedSubjectsRepository.InsertCompletedSubject(completedSubjects);
        }

        [HttpPost("addmulticompletedsubjects")]
        public void AddMultiCompletedSubject(List<CompletedSubjects> completedSubjects)
        {
            foreach (CompletedSubjects cs in completedSubjects) {
                completedSubjectsRepository.InsertCompletedSubject(cs);
            }
        }


        [HttpPost("getcompletedsubjects")]
        public List<CompletedSubjects> GetCompletedSubjects(string userId) {
            return completedSubjectsRepository.GetCompletedSubjects(userId);
        }

    }
}
