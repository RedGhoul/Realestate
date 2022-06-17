namespace RealEstate.Models.ViewModels;

public class DetailsViewModel
{
    public string MapBoxApiKey { get; set; }
    public Home mainHome { get; set; }
    public List<Home> relatedHomesSide { get; set; }
    public List<Home> relatedHomesBottom { get; set; }
}