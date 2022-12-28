using AutoMapper;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Sectors;
using ServisTakip.Entities.DTOs.User;
using ServisTakip.Entities.DTOs.Cities;
using ServisTakip.Entities.DTOs.Districts;
using ServisTakip.Entities.DTOs.Querters;

namespace ServisTakip.Business.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<Sector, SectorDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<Querter, QuerterDto>().ReverseMap();
        }
    }
}
