using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using PROJ.Models;
using PROJ.Interface;

namespace PROJ.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private IMongoCollection<Subject> _subjects;

        public SubjectRepository(IMyDataBaseSettings settings)
        {

            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _subjects = database.GetCollection<Subject>("raw_subjects");
        }

        public void DeleteSubject(string Id)
        {
            throw new NotImplementedException();
        }

        public Subject GetSubjectById(string Id) =>
            _subjects.Find(subject => subject.Id.Equals(Id)).First();

        public Subject GetSubjectByCode(string code) =>
            _subjects.Find(subject => subject.subjectCode.Equals(code)).FirstOrDefault();
            
        public IEnumerable<Subject> GetSubjects() =>
            _subjects.Find<Subject>(new BsonDocument()).ToList();

        public void InsertSubject(Subject Subject)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateSubject(Subject Subject)
        {
            throw new NotImplementedException();
        }

        // To  be added
        // public Subject GetSubjectByID(string SubjectId) =>


    }
}