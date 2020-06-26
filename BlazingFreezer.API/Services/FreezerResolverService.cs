using System.Threading.Tasks;
using Grpc.Core;

namespace BlazingFreezer.API.Services
{
    public class FreezerResolverService : FreezerService.FreezerServiceBase
    {
        public override Task<FreezerOverviewReply> GetFreezerOverview(FreezerOverviewRequest request,
            ServerCallContext context)
        {
            var kitchen = new FreezerOverviewItem() {Id = "1", Name = "Keuken"};
            var garage = new FreezerOverviewItem() {Id = "2", Name = "Garage"};
            
            var ret = new FreezerOverviewReply();
            ret.Items.Add(kitchen);
            ret.Items.Add(garage);

            return Task.FromResult(ret);    
        }
    }
}