using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PROJ.Models;
using PROJ.Services;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using MongoDB.Driver;

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

        [HttpPost("addUserPreferences")]
        public async Task AddUserPreferences(string userId, bool groupWork, bool essays, bool presentations, bool exams, string[] interests )
        {
            var userPreferences = new UserPreferences()
            {
                UserId = userId,
                Groupwork = groupWork,
                Essays = essays,
                Presentations = presentations,
                Exams = exams,
                Interests = interests
            };

            await _userPreferencesRepository.InsertOneAsync(userPreferences);
        }

        [HttpPost("deleteUserPreferences")]
        public async Task DeleteUserSubject(string SubjectId, string UserId)
        {
            await _userPreferencesRepository.DeleteManyAsync(userPreferences => userPreferences.UserId == UserId);
        }

        [HttpPost("updateUserPreferences")]
        public async Task UpdateUserSubject(string userId, bool groupWork, bool essays, bool presentations, bool exams, string[] interests)
        {
            var updatedPrefs = new UserPreferences()
            {
                UserId = userId,
                Groupwork = groupWork,
                Essays = essays,
                Presentations = presentations,
                Exams = exams,
                Interests = interests
            };
            await _userPreferencesRepository.ReplaceOneAsync(_userPreferencesRepository.FilterBy(s => s.UserId == userId).First());

        }

    }
}