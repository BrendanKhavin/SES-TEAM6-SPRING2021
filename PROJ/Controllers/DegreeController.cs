using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PROJ.Interface;
using PROJ.Models;
using PROJ.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PROJ.Controllers
{
    [Route("api/degrees")]
    [ApiController]
    public class DegreesController : Controller
    {

        private IDegreeRepository  degreeRepository;

        public DegreesController(IDegreeRepository degreeRepository)
        {
            this.degreeRepository = degreeRepository;
        }

        [HttpGet]
        public List<Degree> GetDegrees() =>
            degreeRepository.GetDegrees().ToList();

        // route is: api/degrees/{code}
        [HttpGet("{code:length(6)}")]
        public Degree GetDegreeByCode(string code) =>
            degreeRepository.GetDegreeByCode(code);

    }
}
