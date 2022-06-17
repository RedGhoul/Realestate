namespace RealEstate.Models;

public class IndexViewModel
{
    public List<string?> City { get; set; }
    public List<string?> LandType { get; set; }
    public List<Home> RandomHomes { get; set; }
    public List<CountModel> CountByCity { get; set; }
    public int ListingCount { set; get; }
    public List<String> Cities { get; set; }
    public List<String> Landtypes { get; set; }
}