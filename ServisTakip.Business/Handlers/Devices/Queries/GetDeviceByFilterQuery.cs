using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceByFilterQuery : IRequest<ResponseMessage<List<SearchCustomerDto>>>
    {
        public string Filter { get; set; }
        public class GetDeviceByFilterQueryHandler : IRequestHandler<GetDeviceByFilterQuery, ResponseMessage<List<SearchCustomerDto>>>
        {
            public async Task<ResponseMessage<List<SearchCustomerDto>>> Handle(GetDeviceByFilterQuery request, CancellationToken cancellationToken)
            {
                var customerRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                List<SearchCustomerDto> result = new List<SearchCustomerDto>();

                var deviceList = await customerRepo.GetDeviceByFilterAsync(request.Filter, cancellationToken);
                foreach (var device in deviceList)
                {
                    var cst = new SearchCustomerDto
                    {
                        Title = device.Address.Customer.Title,
                        Id = device.Address.Customer.Id,
                        Sector = device.Address.Customer.Sector.Name,
                        AddressId = device.Address.Id,
                        DeviceId = device.Id,
                        Address = device.Address.AddressTitle,
                        Querter = device.Address.Querter.Name,
                        Model = device.DeviceModel.Name,
                        SerialNo = device.SerialNumber
                    };

                    result.Add(cst);
                }

                foreach (var item in result)
                {
                    item.RowId = $"{item.Id}|{item.AddressId}|{item.DeviceId}";
                }

                return ResponseMessage<List<SearchCustomerDto>>.Success(result);
            }
        }
    }
}
