using System;
using System.Collections.Generic;

namespace RealEstate.Models
{
    public partial class Searchlocation
    {
        public int Id { get; set; }
        public string? LocationName { get; set; }
        public int? ScrapingConfigFkId { get; set; }

        public virtual Scraperconfig? ScrapingConfigFk { get; set; }
    }
}
