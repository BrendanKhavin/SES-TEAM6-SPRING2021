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

            _rawSubjects = database.GetCollection<rawSubjects>(settings.CollectionName);
        }

        //List where we pull the data. This is a TEST feature 
        public List<rawSubjects> Get()
        {
            List<rawSubjects> rawSubjects;
            rawSubjects = _rawSubjects.Find(emp => true).ToList();
            return rawSubjects;
        }

        public rawSubjects Get(int SubjectCode) =>
        _rawSubjects.Find<rawSubjects>(emp => emp.subjectCode == SubjectCode).FirstOrDefault();
       



        public DatabaseServices()
        {
        }
    }
}
