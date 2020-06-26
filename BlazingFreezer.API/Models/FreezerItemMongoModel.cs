using MongoDB.Bson.Serialization.Attributes;

namespace BlazingFreezer.API.Models
{
    public class FreezerItemMongoModel
    {
        [BsonElement("name")]
        public string Name { get; set; }
    }
}