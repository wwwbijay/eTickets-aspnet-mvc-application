using AutoMapper;
using Hotel_Listing.Data;
using Hotel_Listing.Models;

namespace Hotel_Listing.Configurations
{
    public class MapperInitizlizer : Profile
    {
        public MapperInitizlizer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<Hotel, CreateHotelDTO>().ReverseMap();
        }
    }
}
