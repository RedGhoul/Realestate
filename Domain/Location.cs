using System;
using System.Collections.Generic;

namespace RealEstate.Models
{
    public partial class Location
    {
        public int Id { get; set; }
        public string? ExactAddress { get; set; }
        public string? City { get; set; }
        public string? HouseNumber { get; set; }
        public double? Lat { get; set; }
        public double? Long { get; set; }
        public string? PostalCode { get; set; }
        public string? MapBoxResult { get; set; }

        public virtual Home? Home { get; set; }
    }
}
