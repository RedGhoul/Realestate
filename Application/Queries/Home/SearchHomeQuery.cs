using Application.Response;
using MediatR;

namespace RealEstate.Application.Queries;

public class SearchHomeQuery : IRequest<SearchHomeResponse>
{
    public string? keyWords { get; set; }
    public string? city { get; set; }
    public string? landtype { get; set; }
    public int beds { get; set; }
    public int baths { get; set; }
}