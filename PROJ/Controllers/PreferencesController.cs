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
    public class PreferencesController : Controller
    {
        [Route("api/studentPreferences")]
        [ApiController]
        public class SubjectsController : Controller
        {

            private IPreferences preferencesRepository;

            public SubjectsController(IPreferences studentRepository)
            {
                this.preferencesRepository = studentRepository;
            }

            [HttpGet]
            public List<Preferences> GetStudentPreferences() =>
                preferencesRepository.GetPreferences();


            // NOT SURE
            [HttpGet("{subjectCode:length(5)}")]
            public Preferences GetSubjectByCode(int id) =>
                preferencesRepository.GetbyID(id);
        }
    }
}
