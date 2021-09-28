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
            //filter for the rawSubject
            _rawSubjects = database.GetCollection<rawSubjects>(settings.CollectionName);
        }

        //List where we pull the data. This is a TEST feature 
        public List<rawSubjects> Get() =>
            _rawSubjects.Find(rawSubject => true).ToList();

        public rawSubjects Get(string subjectCode) =>
            _rawSubjects.Find<rawSubjects>(emp => emp.subjectCode.Equals(subjectCode)).FirstOrDefault();
<<<<<<< HEAD
=======


  
>>>>>>> e9e78dbf26b4f586e6bcf615d7c998cf0f49bd3d


        public List<rawSubjects> GetCourses(String courseArea)
        {
            if (courseArea == "Engineering")
                //put into a repository
                //call the entire function
                //reuse this function
            {
                var filterDefinition = Builders<rawSubjects>.Filter.Eq(a => a.courseArea, "Engineering");
                var filtered_subjects = _rawSubjects.Find(filterDefinition).ToList();
                return filtered_subjects;
            }
            return null;
        }

 


        public DatabaseServices()
        {
        }
    }
}
