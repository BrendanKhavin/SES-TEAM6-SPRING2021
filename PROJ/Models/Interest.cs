using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PROJ.Models
{
    public class Interest
    {
        
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]       
        public string name { get; set; }
    }
}