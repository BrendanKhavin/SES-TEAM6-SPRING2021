using System;
using PROJ.Models;
using PROJ.Interface;
using MongoDB.Driver;
using System.Linq;
using System.Collections.Generic;


namespace PROJ.Repository
{
    public class CompletedSubjectsRepository : ICompletedSubjectsRepository
    {

        private readonly IMongoCollection<CompletedSubjects> _completedSubjects;


        public CompletedSubjectsRepository(IMyDataBaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _completedSubjects = database.GetCollection<CompletedSubjects>("CompletedSubjects");
        }

        public void DeleteCompletedSubject(string userID, CompletedSubjects completedSubject)
        {
            _completedSubjects.FindOneAndDelete<CompletedSubjects>(emp => emp.UserId.Equals(userID));

        }

        public List<CompletedSubjects> GetCompletedSubjects(string userID) =>
            _completedSubjects.Find<CompletedSubjects>(emp => emp.UserId.Equals(userID)).ToList();



        public void InsertCompletedSubject(CompletedSubjects completedSubjects)
        {
            _completedSubjects.InsertOneAsync(completedSubjects);

        }


    }

}