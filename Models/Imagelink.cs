using System;
using System.Collections.Generic;

namespace RealEstate.Models
{
    public partial class Imagelink
    {
        public int Id { get; set; }
        public string? Link { get; set; }
        public int? HomeFkId { get; set; }

        public virtual Home? HomeFk { get; set; }
    }
}
