using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Customers.Queries
{
    public class GetLastTradedCustomerQuery : IRequest<ResponseMessage<LastTradedCustomerInfoDto>>
    {
        public class GetLastTradedCustomerQueryHandler : IRequestHandler<GetLastTradedCustomerQuery, ResponseMessage<LastTradedCustomerInfoDto>>
        {
            public async Task<ResponseMessage<LastTradedCustomerInfoDto>> Handle(GetLastTradedCustomerQuery request, CancellationToken cancellationToken)
            {
                LastTradedCustomerInfoDto result = new LastTradedCustomerInfoDto();

                var deviceServicesRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var lastService = await deviceServicesRepo.GetLastTradedCustomerInfo();
                if (lastService != null)
                {
                    result.CustomerTitle = lastService.Device.Address.Customer.Title;
                    result.CustomerId = lastService.Device.Address.Customer.Id;
                    result.CustomerSector = lastService.Device.Address.Customer.SectorId;
                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }

                var deviceRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();
                var lastDevice = await deviceRepo.GetLastTradedCustomerInfo();
                if (lastDevice != null)
                {
                    result.CustomerTitle = lastDevice.Address.Customer.Title;
                    result.CustomerId = lastDevice.Address.Customer.Id;
                    result.CustomerSector = lastDevice.Address.Customer.SectorId;
                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }

                var customerRepo = ServiceTool.ServiceProvider.GetService<ICustomerRepository>();
                var lastCustomerList = await customerRepo.GetListAsync(s => s.RecordUsername == Utils.Email);
                
                if (lastCustomerList != null && lastCustomerList.Any())
                {
                    var lastCustomer = lastCustomerList.OrderByDescending(s=>s.RecordDate).First();
                    result.CustomerTitle = lastCustomer.Title;
                    result.CustomerId = lastCustomer.Id;
                    result.CustomerSector = lastCustomer.SectorId;
                    return ResponseMessage<LastTradedCustomerInfoDto>.Success(result);
                }

                return ResponseMessage<LastTradedCustomerInfoDto>.Fail("Son İşlem Bilgisi Alınamadı.");
            }
        }
    }
}
