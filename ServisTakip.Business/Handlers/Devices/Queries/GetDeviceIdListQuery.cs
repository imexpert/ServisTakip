using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Devices.Queries
{
    public class GetDeviceIdListQuery : IRequest<ResponseMessage<List<long>>>
    {
        public string Filter { get; set; }
        public class GetDeviceIdListQueryHandler : IRequestHandler<GetDeviceIdListQuery, ResponseMessage<List<long>>>
        {
            public async Task<ResponseMessage<List<long>>> Handle(GetDeviceIdListQuery request, CancellationToken cancellationToken)
            {
                var deviceRepo = ServiceTool.ServiceProvider.GetService<IDeviceRepository>();

                var deviceList = await deviceRepo.Query()
                    .Include(s => s.Address).ThenInclude(s => s.Customer)
                    .Where(s => s.Address.Customer.CompanyId == Utils.CompanyId)
                    .Select(s => s.Id)
                    .ToListAsync();

                return ResponseMessage<List<long>>.Success(deviceList);
            }
        }
    }
}
