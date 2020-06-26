using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BlazingFreezer.API.Services
{
    public class FreezerResolverService : FreezerService.FreezerServiceBase
    {
        private readonly IMongoService _mongoService;

        public FreezerResolverService(IMongoService mongoService)
        {
            _mongoService = mongoService;
        }
        
        public override async Task<FreezerOverviewReply> GetFreezerOverview(FreezerOverviewRequest request,
            ServerCallContext context)
        {
            var projection = new FindExpressionProjectionDefinition<BsonDocument, FreezerOverviewItem>(p => new FreezerOverviewItem
            {
                Id = p["_id"].ToString(),
                Name = p["name"].AsString
            });


            var items = await _mongoService
                .GetDatabase()
                .GetCollection<BsonDocument>("freezers")
                .Find(_ => true)
                .Project(projection)
                .ToListAsync();
            var ret = new FreezerOverviewReply();
            ret.Items.AddRange(items);
            return ret;
        }
    }
}