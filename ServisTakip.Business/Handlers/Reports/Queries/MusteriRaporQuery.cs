using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Reports;
using ServisTakip.Core.Extensions;

namespace ServisTakip.Business.Handlers.Reports.Queries
{
    public class MusteriRaporQuery : IRequest<PagedResult<List<CustomerReportDto>>>
    {
        public MusteriRaporFilter Model { get; set; }
        public class MusteriRaporQueryHandler : IRequestHandler<MusteriRaporQuery, PagedResult<List<CustomerReportDto>>>
        {
            public async Task<PagedResult<List<CustomerReportDto>>> Handle(MusteriRaporQuery request, CancellationToken cancellationToken)
            {
                var pagedResult = new PagedResult<List<CustomerReportDto>>();

                var contractRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();

                var customerQuery = contractRepo.GetMusteriRaporQuery();

                if (request.Model.CustomerId.HasValue)
                    customerQuery = customerQuery.Where(s => s.Id == request.Model.CustomerId);

                if (request.Model.SehirId.HasValue)
                    customerQuery = customerQuery.Where(s => s.Addresses.Any(t => t.District.CityId == request.Model.SehirId));

                if (request.Model.IlceId.HasValue)
                    customerQuery = customerQuery.Where(s => s.Addresses.Any(t => t.DistrictId == request.Model.IlceId));

                if (request.Model.Model.HasValue)
                    customerQuery = customerQuery.Where(s => s.Addresses.Any(t => t.Devices.Any(r => r.DeviceModelId == request.Model.Model)));

                if(!string.IsNullOrEmpty(request.Model.SerialNo))
                    customerQuery = customerQuery.Where(s => s.Addresses.Any(t =>t.Devices.Any(r=> EF.Functions.Like(r.SerialNumber, $"%{request.Model.SerialNo}%"))));

                pagedResult.PageCount = await customerQuery.CountAsync(cancellationToken: cancellationToken);

                customerQuery = customerQuery
                    .Skip((request.Model.CurrentPage - 1) * request.Model.PageSize)
                    .Take(request.Model.PageSize);

                var customers = await customerQuery
                    .ToListAsync(cancellationToken);

                List<CustomerReportDto> result = new();

                foreach (Customer customer in customers)
                {
                    CustomerReportDto item = new CustomerReportDto()
                    {
                        Unvan = customer.Title,
                        CustomerId = customer.Id
                    };

                    if (customer.Addresses.Any())
                    {
                        foreach (Address address in customer.Addresses)
                        {
                            item.Sehir = address.District.City.Name;
                            item.Ilce = address.District.Name;
                            item.Semt = address.QuerterName;
                            item.AddressId = address.Id;

                            if (address.Devices.Any())
                            {
                                foreach (Device device in address.Devices)
                                {
                                    item.Tip = device.DeviceModel.DeviceBrand.DeviceType.Name;
                                    item.Marka = device.DeviceModel.DeviceBrand.Name;
                                    item.Model = device.DeviceModel.Name;
                                    item.CihazSeriNo = device.SerialNumber;
                                    item.MontajTarihi = device.AssemblyDate.ToString("dd/MM/yyyy");
                                    item.DeviceId = device.Id;

                                    if (device.Contracts.Any())
                                    {
                                        var lastContract = device.Contracts.MaxBy(s => s.EndDate);
                                        if (lastContract != null && lastContract.EndDate >= DateTime.Now)
                                        {
                                            item.SozlesmeKodu = lastContract.ContractCode;
                                            item.BaslangicTarihi = lastContract.StartDate.ToString("dd/MM/yyyy");
                                            item.BitisTarihi = lastContract.EndDate.ToString("dd/MM/yyyy");
                                        }
                                        else
                                        {
                                            item.SozlesmeKodu = "ÜCRETLİ";
                                        }

                                        result.Add(item.Clone());
                                    }
                                    else
                                    {
                                        result.Add(item.Clone());
                                    }
                                }
                            }
                            else
                            {
                                result.Add(item.Clone());
                            }
                        }
                    }
                    else
                    {
                        result.Add(item.Clone());
                    }
                }

                pagedResult.Data = result;
                pagedResult.PageSize = request.Model.PageSize;
                pagedResult.CurrentPage = request.Model.CurrentPage;
                pagedResult.IsSuccess = true;
                return pagedResult;
            }
        }
    }
}
