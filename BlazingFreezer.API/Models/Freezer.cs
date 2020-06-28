using System.Collections.Generic;

namespace BlazingFreezer.API.Models
{
    public class Freezer
    {
        public int FreezerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<FreezerDrawer> FreezerDrawers { get; set; }
    }
}