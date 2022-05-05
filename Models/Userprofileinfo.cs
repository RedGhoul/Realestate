using System;
using System.Collections.Generic;

namespace RealEstate.Models
{
    public partial class Userprofileinfo
    {
        public int Id { get; set; }
        public int UserFkId { get; set; }

        public virtual AuthUser UserFk { get; set; } = null!;
    }
}
