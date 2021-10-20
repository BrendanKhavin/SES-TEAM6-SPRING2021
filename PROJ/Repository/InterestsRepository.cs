using System.Linq;
using MongoDB.Driver;
using PROJ.Models;
using PROJ.Interface;

namespace PROJ.Repository
{
    public class InterestsRepository : IInterestsRepository
    {
        private IMongoCollection<Interest> _interests;

        public InterestsRepository(IMyDataBaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _interests = database.GetCollection<Interest>("interests");
        }

        public string[] GetInterests() =>
           (from i in _interests.AsQueryable() select i.name).ToArray();
        
    }
}