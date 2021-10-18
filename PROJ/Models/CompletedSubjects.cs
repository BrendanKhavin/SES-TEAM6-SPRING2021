using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace PROJ.Models
{

    [BsonIgnoreExtraElements]
    public class CompletedSubjects
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("UserId")]
        public string UserId { get; set; }

        [BsonElement("SubjectId")]
        public string SubjectId { get; set; }

        [BsonElement("Score")]
        public int Score { get; set; }

        public CompletedSubjects()
        {

        }

    }
}

