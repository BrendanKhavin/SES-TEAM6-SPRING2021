using Microsoft.AspNetCore.Mvc;
using PROJ.Interface;
using PROJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJ.Controllers
{
    public class SubjectController : Controller
    {
  
        public ICompletedSubjectsRepository completedSubjectsRepository { get; set; }

        public SubjectController(ICompletedSubjectsRepository completedSubjectsRepository){
            this.completedSubjectsRepository = completedSubjectsRepository; 
        }

        public void AddCompletedSubject(CompletedSubjects completedSubjects){
            completedSubjectsRepository.InsertCompletedSubject(completedSubjects);
        }

        public List<CompletedSubjects> GetCompletedSubjects(string userId) {
            return completedSubjectsRepository.GetCompletedSubjects(userId);
        }

    }
}
