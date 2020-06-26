using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazingFreezer.API.Models
{
    public class FreezerItemMongoModel
    {
        [BsonId] public ObjectId Id { get; set; }
        [BsonElement("name")] public string Name { get; set; }
        [BsonElement("since")] public DateTime Since { get; set; }
        [BsonElement("isVacuum")] public bool IsVacuum { get; set; }
    }
}