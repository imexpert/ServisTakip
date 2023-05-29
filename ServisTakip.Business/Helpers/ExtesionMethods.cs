using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.CrossCuttingConcerns.Caching;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.DataAccess.Abstract;

namespace ServisTakip.Business.Helpers
{
    public static class Tools
    {
        public static IMediator Mediator => ServiceTool.ServiceProvider.GetService<IMediator>();
        public static IDistrictRepository DistrictRepository => ServiceTool.ServiceProvider.GetService<IDistrictRepository>();
        public static IGroupRepository GroupRepository => ServiceTool.ServiceProvider.GetService<IGroupRepository>();
        public static IDetectionCodeRepository DetectionCodeRepository => ServiceTool.ServiceProvider.GetService<IDetectionCodeRepository>();
        public static IDeviceBrandRepository DeviceBrandRepository => ServiceTool.ServiceProvider.GetService<IDeviceBrandRepository>();
        public static IDeviceTypeRepository DeviceTypeRepository => ServiceTool.ServiceProvider.GetService<IDeviceTypeRepository>();
        public static IDeviceModelRepository DeviceModelRepository => ServiceTool.ServiceProvider.GetService<IDeviceModelRepository>();
        public static IOfferSubjectCodeRepository OfferSubjectCodeRepository => ServiceTool.ServiceProvider.GetService<IOfferSubjectCodeRepository>();
        public static ISectorRepository SectorRepository => ServiceTool.ServiceProvider.GetService<ISectorRepository>();
        public static IDeviceServicePartRepository DeviceServicePartRepository => ServiceTool.ServiceProvider.GetService<IDeviceServicePartRepository>();
        public static IResultCodeRepository ResultCodeRepository => ServiceTool.ServiceProvider.GetService<IResultCodeRepository>();
        public static IOfferRepository OfferRepository => ServiceTool.ServiceProvider.GetService<IOfferRepository>();
        public static IUserGroupRepository UserGroupRepository => ServiceTool.ServiceProvider.GetService<IUserGroupRepository>();
        public static IContractCodeRepository ContractCodeRepository => ServiceTool.ServiceProvider.GetService<IContractCodeRepository>();
        public static IBootCodeRepository BootCodeRepository => ServiceTool.ServiceProvider.GetService<IBootCodeRepository>();
        public static ICompanyRepository CompanyRepository => ServiceTool.ServiceProvider.GetService<ICompanyRepository>();
        public static ICacheManager CacheManager => ServiceTool.ServiceProvider.GetService<ICacheManager>();
        public static IMapper Mapper => ServiceTool.ServiceProvider.GetService<IMapper>();
        public static IHttpContextAccessor HttpContextAccessor => ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        public static IUserProcessRepository UserProcessRepository => ServiceTool.ServiceProvider.GetService<IUserProcessRepository>();
        public static ICityRepository CityRepository => ServiceTool.ServiceProvider.GetService<ICityRepository>();
        public static IContractRepository ContractRepository => ServiceTool.ServiceProvider.GetService<IContractRepository>();
        public static IUserRepository UserRepository => ServiceTool.ServiceProvider.GetService<IUserRepository>();
        public static IAddressRepository AddressRepository => ServiceTool.ServiceProvider.GetService<IAddressRepository>();
        public static IContractMaintenanceRepository ContractMaintenanceRepository => ServiceTool.ServiceProvider.GetService<IContractMaintenanceRepository>();
        public static ICustomerRepository CustomerRepository => ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
        public static IDeviceRepository DeviceRepository => ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
        public static IDeviceServiceRepository DeviceServiceRepository => ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
    }
}
