using System.Collections.Generic;

namespace BlazingFreezer.API.Models
{
    public class FreezerDrawer
    {
        public int FreezerDrawerId { get; set; }
        public int FreezerId { get; set; }
        public string Name { get; set; }
        public IEnumerable<FreezerItem> FreezerItems { get; set; }
    }
}