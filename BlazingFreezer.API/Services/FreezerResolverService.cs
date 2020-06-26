using System.Collections.Generic;
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

        private static IEnumerable<FreezerDetailsItem> ConvertToItemList(FreezerMongoModel freezerMongoModel)
        {
            return (from drawer in (freezerMongoModel.Drawers ?? new FreezerDrawerMongoModel[0])
                from item in (drawer.Items ?? new FreezerItemMongoModel[0])
                select new FreezerDetailsItem()
                {
                    Name = item.Name,
                    Since = item.Since.ToShortDateString(),
                    DrawerId = drawer.Id.ToString(),
                    IsVacuum = item.IsVacuum,
                    ItemId = item.Id.ToString()
                }).ToList();
        }


        public override async Task<FreezerDetailsReply> GetFreezerDetails(FreezerDetailsRequest request, ServerCallContext context)
        {
            var projection = new FindExpressionProjectionDefinition<FreezerMongoModel, IEnumerable<FreezerDetailsItem>>(p => ConvertToItemList(p));
            var items = await _mongoService
                .GetDatabase()
                .GetCollection<FreezerMongoModel>("freezers")
                .Find(x => x.Id == ObjectId.Parse(request.FreezerId))
                .Project(projection)
                .ToListAsync();
            var ret = new FreezerDetailsReply();
            ret.Items.AddRange(items.SelectMany(x => x).ToList());
            return ret;
        }

        public override async Task<FreezerOverviewReply> GetFreezerOverview(FreezerOverviewRequest request,
            ServerCallContext context)
        {
            var projection = new FindExpressionProjectionDefinition<FreezerMongoModel, FreezerOverviewItem>(p =>
                new FreezerOverviewItem
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