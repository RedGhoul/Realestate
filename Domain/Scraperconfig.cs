using System;
using System.Collections.Generic;

namespace RealEstate.Models
{
    public partial class Scraperconfig
    {
        public Scraperconfig()
        {
            Searchlocations = new HashSet<Searchlocation>();
        }

        public int Id { get; set; }
        public string BaseDomain { get; set; } = null!;
        public string ScrapConfigName { get; set; } = null!;

        public virtual ICollection<Searchlocation> Searchlocations { get; set; }
    }
}
