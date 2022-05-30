using System;
using System.Collections.Generic;
using NpgsqlTypes;

namespace RealEstate.Models
{
    public partial class Realestatebroker
    {
        public Realestatebroker()
        {
            Brokeragephonenumbers = new HashSet<Brokeragephonenumber>();
            Homes = new HashSet<Home>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Brokerage { get; set; } = null!;
        public string BrokerageWebsite { get; set; } = null!;

        public virtual ICollection<Brokeragephonenumber> Brokeragephonenumbers { get; set; }
        public virtual ICollection<Home> Homes { get; set; }
    }
}
