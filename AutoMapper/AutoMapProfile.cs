using AutoMapper;
using RealEstate.Models;
using RealEstate.Models.Dtos;

namespace RealEstate.AutoMapper;

public class AutoMapProfile : Profile
{

    public AutoMapProfile()
    {
        CreateMap<Home, HomeDto>()
            .ForMember(dest => dest.Imagelinks,
                opt => opt.MapFrom(
                    x => x.Imagelinks))
            .ForMember(dest => dest.Rooms,
                opt => opt.MapFrom(
                    x => x.Rooms))
            .ReverseMap();
    }
}