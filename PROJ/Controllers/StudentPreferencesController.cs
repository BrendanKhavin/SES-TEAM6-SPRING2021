using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PROJ.Interface;
using PROJ.Models;
using PROJ.Repository;
;

namespace PROJ.Controllers
{
    public class StudentPreferencesController : Controller
    {
        [Route("api/studentPreferences")]
        [ApiController]
        public class SubjectsController : Controller
        {

            private IStudentPreferences studentPreferencesRepository;

            public SubjectsController(IStudentPreferences studentRepository)
            {
                this.studentPreferencesRepository = studentRepository;
            }

            [HttpGet]
            public List<StudentPreferences> GetStudentPreferences() =>
                studentPreferencesRepository.GetPreferences();


            // NOT SURE
            [HttpGet("{subjectCode:length(5)}")]
            public StudentPreferences GetSubjectByCode(int id) =>
                studentPreferencesRepository.GetbyID(id);
        }
    }
}
