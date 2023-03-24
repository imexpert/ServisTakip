using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Customers.Queries
{
    public class GetCustomerByFilterQuery : IRequest<ResponseMessage<List<SearchCustomerDto>>>
    {
        public string Filter { get; set; }
        public class GetCustomerByFilterQueryHandler : IRequestHandler<GetCustomerByFilterQuery, ResponseMessage<List<SearchCustomerDto>>>
        {
            public async Task<ResponseMessage<List<SearchCustomerDto>>> Handle(GetCustomerByFilterQuery request, CancellationToken cancellationToken)
            {
                var customerRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                List<SearchCustomerDto> result = new List<SearchCustomerDto>();

                var customerList = await customerRepo.GetCustomerByFilterAsync(request.Filter, cancellationToken);
                foreach ( var customer in customerList )
                {
                    var cst = new SearchCustomerDto
                    {
                        Title = customer.Title,
                        Id = customer.Id,
                        Sector = customer.Sector.Name,
                        AddressId = 0,
                        DeviceId = 0
                    };

                    if (customer.Addresses.Count > 0)
                    {
                        foreach (var address in customer.Addresses)
                        {
                            if (address.Devices.Count > 0)
                            {
                                foreach (var device in address.Devices)
                                {
                                    cst.AddressId = address.Id;
                                    cst.Address = address.AddressTitle;
                                    cst.District = address.District.Name;
                                    cst.DeviceId = device.Id;
                                    cst.Model = device.DeviceModel.Name;
                                    cst.SerialNo = device.SerialNumber;
                                    cst.Department = address.Department;

                                    result.Add(cst.Clone());

                                }
                            }
                            else
                            {
                                cst.District = null;
                                cst.DeviceId = 0;
                                cst.Model = null;
                                cst.SerialNo = null;
                                cst.AddressId = address.Id;
                                cst.Address = address.AddressTitle;
                                cst.District = address.District.Name;
                                cst.Department = address.Department;
                                result.Add(cst.Clone());
                            }
                        }
                    }
                    else
                    {
                        result.Add(cst.Clone());
                    }
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
