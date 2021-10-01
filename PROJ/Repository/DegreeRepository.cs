using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using PROJ.Models;
using PROJ.Interface;

namespace PROJ.Repository
{
    public class DegreeRepository : IDegreeRepository
    {
        private IMongoCollection<Degree> _degrees;

        public DegreeRepository(IMyDataBaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _degrees = database.GetCollection<Degree>("degrees");
        }

        public void DeleteDegree(string Id)
        {
            throw new NotImplementedException();
        }

        public Degree GetDegreeById(string Id) =>
            _degrees.Find(degree => degree.Id.Equals(Id)).First();
        
        public Degree GetDegreeByCode(string code) =>
            _degrees.Find(degree => degree.degreeCode.Equals(code)).First();

        public IEnumerable<Degree> GetDegrees() =>
            _degrees.Find<Degree>(new BsonDocument()).ToList();

        public void InsertDegree(Degree Degree)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateDegree(Degree Degree)
        {
            throw new NotImplementedException();
        }

        // To  be added
        // public Degree GetDegreeByID(string DegreeId) =>


    }
}