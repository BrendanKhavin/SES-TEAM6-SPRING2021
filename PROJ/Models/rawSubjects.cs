using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PROJ.Models
{
    // BsonIgnoreExtraElements is needed to ignore unmapped BSON feilds. e.g. 
    // raw_subjects in MongoDB have Assessments, Descriptions etc, but these 
    // are not represented in the class. Otherwise a FormatException is raised
    [BsonIgnoreExtraElements] 
    public class rawSubjects
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        // The [BsonElement] attribute maps mongoDB document fields to C# class fields
        [BsonElement("code")]       
        // subjectCode is a string instead of int because it shouldn't be used in math operations
        public string subjectCode { get; set; }

        [BsonElement("name")]        
        public string subjectName { get; set; }
        
        [BsonElement("Credit Points")]        
        public int creditPoints { get; set; }

        public rawSubjects()
        {
        }
    }
}
