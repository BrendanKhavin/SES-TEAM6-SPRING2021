using System;
using MongoDB.Bson.Serialization.Attributes;

namespace PROJ.Models

{
    [BsonCollection("StudentEnrolment")]
    public class StudentEnrollment : Document
    {
        //BsonCollection(degree)

        [BsonElement("studentId")]
        public string studentId { get; set; }

        [BsonElement("degreeId")]
        public string degreeId { get; set; }

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
