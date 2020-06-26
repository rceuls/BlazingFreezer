using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazingFreezer.API.Models
{
    public class FreezerMongoModel
    {
        [BsonId] public ObjectId Id { get; set; }
        [BsonElement("name")] public string Name { get; set; }
        [BsonElement("drawers")] public IEnumerable<FreezerDrawerMongoModel> Drawers { get; set; }
    }
}