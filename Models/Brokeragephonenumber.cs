using System;
using System.Collections.Generic;

namespace RealEstate.Models
{
    public partial class Brokeragephonenumber
    {
        public int Id { get; set; }
        public string? PhoneNumber { get; set; }
        public int? RealEstateBrokerFkId { get; set; }

        public virtual Realestatebroker? RealEstateBrokerFk { get; set; }
    }
}
