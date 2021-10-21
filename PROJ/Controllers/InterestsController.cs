using System.Collections.Generic;
using PROJ.Models;
using Microsoft.AspNetCore.Mvc;

namespace PROJ.Controllers
{
    [Route("api/[controller]")]
    public class InterestsController : ControllerBase
    {
      private IMongoRepository<Interest> _interestsRepository;

      public InterestsController(IMongoRepository<Interest> interestsRepository) {
        _interestsRepository = interestsRepository;
      }

      [HttpGet]
      public IEnumerable<string> GetInterests() {
        var interests = new List<string>();
        foreach (Interest i in _interestsRepository.FindAll()) {
          interests.Add(i.name);
        }
        return interests;
      }
    }
}