using AutoMapper;
using RealEstate.Models;
using RealEstate.Models.Dtos;

namespace RealEstate.AutoMapper;

public class AutoMapProfile : Profile
{

    public AutoMapProfile()
    {
        CreateMap<Home, HomeDto>()
            .ReverseMap();
    }
}