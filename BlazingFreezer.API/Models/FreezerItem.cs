using System;

namespace BlazingFreezer.API.Models
{
    public class FreezerItem
    {
        public int FreezerItemId { get; set; }
        public int FreezerDrawerId { get; set; }
        public string Name { get; set; }
        public DateTime Since { get; set; }
        public bool IsVacuum { get; set; }
    }
}