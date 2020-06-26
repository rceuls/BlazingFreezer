using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazingFreezer.API.Models
{
    public class FreezerDrawerMongoModel
    {
        [BsonId] public ObjectId Id { get; set; }
        [BsonElement("name")] public string Name { get; set; }
        [BsonElement("items")] public IEnumerable<FreezerItemMongoModel> Items { get; set; }
    }
}