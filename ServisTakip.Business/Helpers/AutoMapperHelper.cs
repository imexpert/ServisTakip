﻿using AutoMapper;
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
using ServisTakip.Entities.DTOs.Addresses;
using ServisTakip.Entities.DTOs.ContractCodes;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.Devices;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.DTOs.DetectionCodes;
using ServisTakip.Entities.DTOs.DeviceServiceParts;
using ServisTakip.Entities.DTOs.Companies;
using ServisTakip.Entities.DTOs.Groups;
using ServisTakip.Entities.DTOs.Offers;
using ServisTakip.Entities.DTOs.OfferSubjectCodes;
using ServisTakip.Entities.DTOs.UserGroups;

namespace ServisTakip.Business.Helpers
{
    public class AutoMapperHelper : Profile
    {
        public AutoMapperHelper()
        {
            CreateMap<User, CreateUserDto>().ReverseMap();
            CreateMap<User, UpdateUserDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Sector, SectorDto>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<Customer, CreateCustomerDto>().ReverseMap();
            CreateMap<Customer, UpdateCustomerDto>().ReverseMap();
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<BootCode, BootCodeDto>().ReverseMap();
            CreateMap<DeviceBrand, DeviceBrandDto>().ReverseMap();
            CreateMap<DeviceModel, DeviceModelDto>().ReverseMap();
            CreateMap<DeviceType, DeviceTypeDto>().ReverseMap();
            CreateMap<ResultCode, ResultCodeDto>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<UpdateAddressDto, Address>().ReverseMap();
            CreateMap<CreateAddressDto, Address>().ReverseMap();
            CreateMap<Contract, ContractDto>().ReverseMap();
            CreateMap<Device, DeviceDto>().ReverseMap();
            CreateMap<Device, CreateDeviceDto>().ReverseMap();
            CreateMap<DeviceService, CreateBakimFormuDto>().ReverseMap();
            CreateMap<ContractCode, ContractCodeDto>().ReverseMap();
            CreateMap<DeviceServiceDto, DeviceService>().ReverseMap();
            CreateMap<CreateDeviceServiceDto, DeviceService>().ReverseMap();
            CreateMap<DetectionCodeDto, DetectionCode>().ReverseMap();
            CreateMap<CreateDeviceServicePartDto, DeviceServicePart>().ReverseMap();
            CreateMap<DeviceServicePartDto, DeviceServicePart>().ReverseMap();
            CreateMap<OfferSubjectCodeDto, OfferSubjectCode>().ReverseMap();
            CreateMap<Offer, OfferDto>().ReverseMap();
            CreateMap<Offer, CreateOfferDto>().ReverseMap();
            CreateMap<Contract, CreateContractDto>().ReverseMap();
            CreateMap<Contract, UpdateContractDto>().ReverseMap();
            CreateMap<UserGroup, UserGroupDto>().ReverseMap();
            CreateMap<Group, GroupDto>().ReverseMap();
        }
    }
}
