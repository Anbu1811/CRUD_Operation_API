using AutoMapper;
using world.API.DTO.COUNTRY;
using World.API.Models;

namespace world.API.Common
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //destination, soruce
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
        }
    }
}
