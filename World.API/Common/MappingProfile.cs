using AutoMapper;
using world.API.DTO.COUNTRY;
using world.API.DTO.STATE;
using world.API.Models;
using World.API.Models;

namespace world.API.Common
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //destination, soruce
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Country, ShowCountryDTO>().ReverseMap();
            CreateMap<Country, UpdateCountryDTO>().ReverseMap();



            CreateMap<State, CreateStateDTO>().ReverseMap();
            CreateMap<State, ShowStateDTO>().ReverseMap();
            CreateMap<State, UpdateStateDTO>().ReverseMap();
        }
    }
}
