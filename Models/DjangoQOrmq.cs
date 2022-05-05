using System;
using System.Collections.Generic;

namespace RealEstate.Models
{
    public partial class DjangoQOrmq
    {
        public int Id { get; set; }
        public string Key { get; set; } = null!;
        public string Payload { get; set; } = null!;
        public DateTime? Lock { get; set; }
    }
}
