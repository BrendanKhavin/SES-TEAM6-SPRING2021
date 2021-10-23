using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


[BsonCollection("UserPreferences")]
public class UserPreferences : Document
{
    [BsonElement("studentId")]
    public string UserId { get; set; }

    [BsonElement("groupwork")]
    public bool Groupwork { get; set; }

    [BsonElement("essays")]
    public bool Essays { get; set; }

    [BsonElement("presentations")]
    public bool Presentations { get; set; }

    [BsonElement("exams")]
    public bool Exams { get; set; }

    [BsonElement("interests")]
    public string[] Interests { get; set; }

    [BsonElement("international")]
    public bool international { get; set; }
}



