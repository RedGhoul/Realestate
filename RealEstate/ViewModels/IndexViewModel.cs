using RealEstate.Models.Dtos;

namespace RealEstate.Models;

public class IndexViewModel
{
    public List<string?> GroupedCities { get; set; }
    public List<string?> LandType { get; set; }
    public List<HomeDto> RandomHomes { get; set; }
    public List<CountModel> CountByCity { get; set; }
    public string ListingCount { set; get; }
    public List<String> Cities { get; set; }
    public List<String> LandTypesForHomes { get; set; }
}