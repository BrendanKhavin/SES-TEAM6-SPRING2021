using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PROJ.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PROJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DegreesController : Controller
    {

        private IMongoRepository<Degree>  _degreeRepository;

        public DegreesController(IMongoRepository<Degree> degreeRepository)
        {
            _degreeRepository = degreeRepository;
        }

        [HttpGet]
        public IEnumerable<Degree> GetDegrees() =>
            _degreeRepository.FindAll().ToList();

        // route is: api/degrees/{code}
        [HttpGet("{code:length(6)}")]
        public Degree GetDegreeByCode(string code) =>
            _degreeRepository.FindOne(degree => degree.degreeCode == code);

    }
}
