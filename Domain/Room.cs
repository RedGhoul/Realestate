using System;
using System.Collections.Generic;

namespace RealEstate.Models
{
    public partial class Room
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public string? RoomSize { get; set; }
        public int? HomeFkId { get; set; }

        public virtual Home? HomeFk { get; set; }
    }
}
