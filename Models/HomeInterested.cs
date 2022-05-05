using System;
using System.Collections.Generic;

namespace RealEstate.Models
{
    public partial class HomeInterested
    {
        public int Id { get; set; }
        public int HomeId { get; set; }
        public int UserId { get; set; }

        public virtual Home Home { get; set; } = null!;
        public virtual AuthUser User { get; set; } = null!;
    }
}
