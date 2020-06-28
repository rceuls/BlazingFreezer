using System.Linq;
using System.Threading.Tasks;
using BlazingFreezer.API.Models;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace BlazingFreezer.API.Services
{
    public class FreezerResolverService : FreezerService.FreezerServiceBase
    {
        private readonly FreezerDataContext _context;

        public FreezerResolverService(FreezerDataContext context)
        {
            _context = context;
        }

        public override async Task<FreezerDetailsReply> GetFreezerDetails(FreezerDetailsRequest request,
            ServerCallContext context)
        {
            var data = await (from item in _context.Freezers
                              from dr in item.FreezerDrawers
                              from it in dr.FreezerItems
                              where item.FreezerId == request.FreezerId
                              select new FreezerDetailsItem
                              {
                                  Name = it.Name,
                                  DrawerId = dr.FreezerDrawerId,
                                  Since = it.Since.ToShortDateString(),
                                  IsVacuum = it.IsVacuum,
                                  ItemId = it.FreezerItemId
                              }).ToListAsync();

            var returning = new FreezerDetailsReply();
            returning.Items.AddRange(data);
            return returning;
        }

        public override async Task<FreezerOverviewReply> GetFreezerOverview(FreezerOverviewRequest request,
            ServerCallContext context)
        {
            var items = await _context.Freezers.Select(x => new FreezerOverviewItem
            {
                Name = x.Name,
                DrawerCount = x.FreezerDrawers.Count(),
                FreezerId = x.FreezerId,
                ItemCount = 0
            }).ToListAsync();
            var ret = new FreezerOverviewReply();
            ret.Items.AddRange(items);
            return ret;
        }
    }
}