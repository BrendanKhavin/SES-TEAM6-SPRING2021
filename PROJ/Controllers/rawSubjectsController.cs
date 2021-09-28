using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROJ.Models;
using PROJ.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PROJ.Controllers
{
    [Route("api/rawSubjects")]
    [ApiController]
    public class rawSubjectsController : Controller
    {

        private readonly DatabaseServices _databaseService;

        public rawSubjectsController(DatabaseServices databaseServices)
        {
            _databaseService = databaseServices;
        }

        [HttpGet]
        public ActionResult<List<rawSubjects>> Get() =>
            _databaseService.Get();

        // route is: api/rawSubjects/{subjectCode}
        [HttpGet("{subjectCode:length(5)}")]
        public ActionResult<rawSubjects> Get(String subjectCode)
        {

            var emp = _databaseService.Get(subjectCode);

            if (emp == null)
            {

                return NotFound();
            }

            return emp;
        }


        [HttpGet("{courseArea:length(10)}")]
        public ActionResult<rawSubjects> GetCourses(String courseArea) {

            var emp = _databaseService.GetCourses(courseArea);

            if (emp == null)
            {
                return NotFound();
            }

            return emp; 
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
