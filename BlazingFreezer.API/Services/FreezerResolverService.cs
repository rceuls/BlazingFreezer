using System;
using System.Linq;
using System.Threading.Tasks;
using BlazingFreezer.API.Models;
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
            var projection = new FindExpressionProjectionDefinition<FreezerMongoModel, FreezerOverviewItem>(p => new FreezerOverviewItem
            {
                Id = p.Id.ToString(),
                Name = p.Name,
                DrawerCount = p.Drawers.Count(),
                ItemCount = p.Drawers.Where(x => x.Items != null).Sum(x => x.Items.Count())
            });


            var items = await _mongoService
                .GetDatabase()
                .GetCollection<FreezerMongoModel>("freezers")
                .Find(_ => true)
                .Project(projection)
                .ToListAsync();
            var ret = new FreezerOverviewReply();
            ret.Items.AddRange(items);
            return ret;
        }
    }
}