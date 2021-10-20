using PROJ.Interface;
using Microsoft.AspNetCore.Mvc;

namespace PROJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestsController : Controller
    {
      public IInterestsRepository interestsRepository { get; set; }

      public InterestsController(IInterestsRepository interestsRepository) {
        this.interestsRepository = interestsRepository;
      }

      [HttpGet]
      public string[] GetInterests() {
        return interestsRepository.GetInterests();
      }
    }
}