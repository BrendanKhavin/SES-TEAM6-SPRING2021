using System;
using MongoDB.Driver;
using System.Linq;
using PROJ.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PROJ.Services
{
    public class DatabaseServices

        
    {
        private readonly IMongoCollection<rawSubjects> _rawSubjects;
        public DatabaseServices(IMyDataBaseSettings settings) {


            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            //filter for the rawSubjects

       //     var filterDefinition = Builders<rawSubjects>.Filter.Empty;
       //   var filtered_subjects = _rawSubjects.Find(filterDefinition).ToList(); 

            _rawSubjects = database.GetCollection<rawSubjects>(settings.CollectionName);
        }

        //List where we pull the data. This is a TEST feature 
        public List<rawSubjects> Get() =>
            _rawSubjects.Find(rawSubject => true).ToList();

        public rawSubjects Get(string subjectCode) =>
            _rawSubjects.Find<rawSubjects>(emp => emp.subjectCode.Equals(subjectCode)).FirstOrDefault();

        //Want to create a list where i can filter data by courseArea

        public DatabaseServices()
        {
        }
    }
}
