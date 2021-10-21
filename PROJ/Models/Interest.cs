using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace PROJ.Models
{
    [BsonCollection("interests")]
    public class Interest : Document
    {
        
        [BsonElement("name")]       
        public string name { get; set; }
    }
}