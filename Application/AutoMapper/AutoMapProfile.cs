using Application.Dtos;
using AutoMapper;
using RealEstate.Models;
using RealEstate.Models.Dtos;

namespace RealEstate.AutoMapper;

public class AutoMapProfile : Profile
{

    public AutoMapProfile()
    {
        CreateMap<Home, HomeDto>().ReverseMap();
        CreateMap<Imagelink, ImagelinkDto>().ReverseMap();
        CreateMap<Room, RoomDto>().ReverseMap();

    }
}