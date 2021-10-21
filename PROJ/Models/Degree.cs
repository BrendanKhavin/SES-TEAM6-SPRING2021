using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PROJ.Models
{
    [BsonIgnoreExtraElements] 
    [BsonCollection("degrees")]
    public class Degree : Document
    {

        [BsonElement("code")]       
        public string degreeCode { get; set; }

        [BsonElement("name")]        
        public string degreeName { get; set; }
        
        [BsonElement("combined_degree")]        
        public bool combinedDegree { get; set; }

        [BsonElement("area")]        
        public string courseArea { get; set; }

        [BsonElement("majors")]        
        public List<String> majors { get; set; }

        [BsonElement("subjects")]   
        public List<String> subjectSample { get; set; }


    }
}
