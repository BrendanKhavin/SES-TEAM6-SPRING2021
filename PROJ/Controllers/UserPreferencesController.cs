using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PROJ.Models;
using PROJ.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace PROJ.Controllers
{
    [Route("api/[controller]")]
    public class UserPreferencesController : ControllerBase
    {
        private IMongoRepository<UserPreferences>  _userPreferencesRepository;

        public UserPreferencesController(IMongoRepository<UserPreferences> userPreferencesRepository)
        {
            _userPreferencesRepository = userPreferencesRepository;
        }


        [HttpGet]
        public IEnumerable<UserPreferences> GetUserPreferences() =>
            _userPreferencesRepository.FindAll();

        [HttpGet("{userId}")]
        public IEnumerable<UserPreferences> GetUserPreferencesByUserId(string userId) =>
          _userPreferencesRepository.FilterBy(s => s.UserId == userId);

    }
}