﻿using ServisTakip.Core.DataAccess;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.DataAccess.Abstract
{
    public interface IDeviceServiceRepository : IEntityRepository<DeviceService>
    {
        Task<DeviceService> GetLastTradedCustomerInfo();
        Task<List<DeviceService>> GetDeviceServices(long deviceId);
        Task<List<DeviceService>> GetDeviceServiceWithStatusCode(int statusCode);
        Task<List<TechnicianDeviceServiceReportModel>> GetTechnicianDeviceServiceListAsync(long userId, CancellationToken cancellationToken);
        Task<DeviceService> GetDeviceServiceWithId(long id, CancellationToken cancellationToken);
        Task<List<DeviceService>> GetToBeOfferedDeviceServiceWithStatusCode(CancellationToken cancellationToken);
        Task<List<DeviceService>> GetSentOfferedDeviceServiceWithStatusCode(CancellationToken cancellationToken);
        Task<DeviceService> GetSonIslemYapianServis(UserProcess userProcess);
    }
}