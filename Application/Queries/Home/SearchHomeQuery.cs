namespace RealEstate.Application.Queries;

public class SearchHomeQuery
{
    public string? keyWords { get; set; }
    public string? city { get; set; }
    public string? landtype { get; set; }
    public int beds { get; set; }
    public int baths { get; set; }
}