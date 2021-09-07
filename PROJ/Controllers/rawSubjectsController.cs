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

        [HttpGet]
        public ActionResult<rawSubjects> Get(int SubjectCode) {

            var emp = _databaseService.Get(SubjectCode);

            if (emp == null) {

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
