using System;
using MongoDB.Bson.Serialization.Attributes;

namespace PROJ.Models

{
    public class StudentEnrollment : Document
    {
        //BsonCollection(degree)

        [BsonElement("studentId")]
        public int studentId { get; set; }

        [BsonElement("degreeName")]
        public string degreeName { get; set; }

        [BsonElement("major")]
        public string major { get; set; }

        
        public StudentEnrollment()
        {
        }


        //get student degree
        //add student degree

    }
}
