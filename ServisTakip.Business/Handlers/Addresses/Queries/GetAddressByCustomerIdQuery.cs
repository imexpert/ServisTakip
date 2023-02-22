using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Addresses;
using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Business.Handlers.Addresses.Queries
{
    public class GetAddressByCustomerIdQuery : IRequest<ResponseMessage<List<AddressDto>>>
    {
        public long CustomerId { get; set; }
        public class GetAddressByCustomerIdQueryHandler : IRequestHandler<GetAddressByCustomerIdQuery, ResponseMessage<List<AddressDto>>>
        {
            public async Task<ResponseMessage<List<AddressDto>>> Handle(GetAddressByCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var customerRepo = ServiceTool.ServiceProvider.GetService<IAddressRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();
                var addresses = await customerRepo.GetAddressInfoByCustomerId(request.CustomerId, cancellationToken);
                var map = mapper.Map<List<AddressDto>>(addresses);
                return ResponseMessage<List<AddressDto>>.Success(map);
            }
        }
    }
}
