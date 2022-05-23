using AutoMapper;
using CarAppBackend.Models;
using CarAppBackend.DTOs;

namespace CarAppBackend.Mappers
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CarDTO, Car>().ReverseMap();
            CreateMap<CarUpdateDTO, Car>().ReverseMap();
        }
    }
}
