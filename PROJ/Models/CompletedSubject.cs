using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


[BsonCollection("CompletedSubjects")]
public class CompletedSubject : Document
{
  [BsonElement("SubjectId")]
  public string SubjectCode { get; set; }

  public string UserId { get; set; }

  public int Score { get; set; }
}

