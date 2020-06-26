using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;

namespace BlazingFreezer.API.Models
{
    public class FreezerDrawerMongoModel
    {
        [BsonElement("name")]
        public string Name { get; set; }
        
        [BsonElement("items")]
        public IEnumerable<FreezerItemMongoModel> Items { get; set; }
    }
}