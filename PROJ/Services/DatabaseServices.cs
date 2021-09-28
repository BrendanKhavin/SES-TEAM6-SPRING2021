using System;
using MongoDB.Driver;
using System.Linq;
using PROJ.Models;
using System.Collections.Generic;

namespace PROJ.Services
{
    public class DatabaseServices  
    {
        private readonly IMongoCollection<Subject> _subjects;

        public DatabaseServices(IMyDataBaseSettings settings) {


            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _subjects = database.GetCollection<Subject>(settings.CollectionName);
        }

        //List where we pull the data. This is a TEST feature 
        public List<Subject> Get() =>
            _subjects.Find(Subject => true).ToList();

        public Subject Get(string subjectCode) =>
            _subjects.Find<Subject>(emp => emp.subjectCode.Equals(subjectCode)).FirstOrDefault();


  



        public DatabaseServices()
        {
        }
    }
}
