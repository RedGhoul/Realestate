using RealEstate.Models.Dtos;

namespace RealEstate.Models.ViewModels;

public class DetailsViewModel
{
    public string MapBoxApiKey { get; set; }
    public HomeDto mainHome { get; set; }
    public List<List<HomeDto>> relatedHomes { get; set; }
}