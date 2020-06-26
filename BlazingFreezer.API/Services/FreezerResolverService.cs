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
            var items = await _mongoService
                .GetDatabase()
                .GetCollection<BsonDocument>("freezers")
                .FindAsync(new BsonDocument());
            var ret = new FreezerOverviewReply();
            ret.Items.AddRange(items.ToList().Select(x => new FreezerOverviewItem
            {
                Id = x["_id"].ToString(),
                Name = x["name"].AsString
            }));

            return ret;
        }
    }
}