using AutoMapper;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Sectors;
using ServisTakip.Entities.DTOs.User;
using ServisTakip.Entities.DTOs.Cities;
using ServisTakip.Entities.DTOs.Districts;
using ServisTakip.Entities.DTOs.BootCodes;
using ServisTakip.Entities.DTOs.DeviceBrands;
using ServisTakip.Entities.DTOs.DeviceModels;
using ServisTakip.Entities.DTOs.DeviceTypes;
using ServisTakip.Entities.DTOs.ResultCodes;
using ServisTakip.Entities.DTOs.Querters;
using ServisTakip.Entities.DTOs.Addresses;

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
            CreateMap<BootCode, BootCodeDto>().ReverseMap();
            CreateMap<DeviceBrand, DeviceBrandDto>().ReverseMap();
            CreateMap<DeviceModel, DeviceModelDto>().ReverseMap();
            CreateMap<DeviceType, DeviceTypeDto>().ReverseMap();
            CreateMap<ResultCode, ResultCodeDto>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<QuerterDto, Querter>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
        }
    }
}
