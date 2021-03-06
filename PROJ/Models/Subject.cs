using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PROJ.Models
{
  [BsonIgnoreExtraElements]
  [BsonCollection("Subject")]
  public class Subject : Document
  {


    // The [BsonElement] attribute maps mongoDB document fields to C# class fields
    [BsonElement("code")]
    // subjectCode is a string instead of int because it shouldn't be used in math operations
    public string subjectCode { get; set; }

    [BsonElement("name")]
    public string subjectName { get; set; }

    //changed return type to string as it needed to match the mongoDB documents 
    [BsonElement("Credit Points")]
    public string creditPoints { get; set; }

    [BsonElement("Description")]
    public string description { get; set; }

    [BsonElement("Requisites")]
    public string prerequisites { get; set; }

    [BsonElement("course area")]
    public string courseArea { get; set; }

    [BsonElement("Availability")]
    public List<String> availableSessions { get; set; }

    public List<String> topics { get; set; }

    [BsonElement("SLOs")]
    public List<String> subjectLearningOutcomes { get; set; }

    [BsonElement("CILOs")]
    public List<String> courseIntendedLearningOutcomes { get; set; }

    // [BsonElement("Assessment")]        
    // public List<Assessment> assessments { get; set; }
 

    // Not yet implemented
    public class Assessment
    {
      public String type { get; set; }
    }
  }
}
