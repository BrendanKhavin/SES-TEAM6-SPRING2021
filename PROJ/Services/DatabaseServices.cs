using System;
using MongoDB.Driver;
using System.Linq;
using PROJ.Models;
using System.Collections.Generic;

namespace PROJ.Services
{
    public class DatabaseServices  
    {
        private readonly IMongoCollection<rawSubjects> _rawSubjects;
        public DatabaseServices(IMyDataBaseSettings settings) {


            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
          //  var FilterDefinition = _rawSubjects.Find(filterDefinition).ToList(); 

            _rawSubjects = database.GetCollection<rawSubjects>(settings.CollectionName);
        }

        //List where we pull the data. This is a TEST feature 
        public List<rawSubjects> Get() =>
            _rawSubjects.Find(rawSubject => true).ToList();

        public rawSubjects Get(string subjectCode) =>
            _rawSubjects.Find<rawSubjects>(emp => emp.subjectCode.Equals(subjectCode)).FirstOrDefault();

        



        public DatabaseServices()
        {
        }
    }
}
