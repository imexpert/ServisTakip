using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceBySerialNoFilterQuery : IRequest<ResponseMessage<List<SearchCustomerDto>>>
    {
        public string Filter { get; set; }
        public class GetDeviceBySerialNoFilterQueryHandler : IRequestHandler<GetDeviceBySerialNoFilterQuery, ResponseMessage<List<SearchCustomerDto>>>
        {
            public async Task<ResponseMessage<List<SearchCustomerDto>>> Handle(GetDeviceBySerialNoFilterQuery request, CancellationToken cancellationToken)
            {
                var customerRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                List<SearchCustomerDto> result = new List<SearchCustomerDto>();

                var deviceList = await customerRepo.GetDeviceBySerialNoFilterAsync(request.Filter, cancellationToken);
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
