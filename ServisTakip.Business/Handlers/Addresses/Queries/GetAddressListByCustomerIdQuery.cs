using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Addresses;

namespace ServisTakip.Business.Handlers.Addresses.Queries
{
    public class GetAddressListByCustomerIdQuery : IRequest<ResponseMessage<List<AddressDto>>>
    {
        public long CustomerId { get; set; }
        public class GetAddressListByCustomerIdQueryHandler : IRequestHandler<GetAddressListByCustomerIdQuery, ResponseMessage<List<AddressDto>>>
        {
            public async Task<ResponseMessage<List<AddressDto>>> Handle(GetAddressListByCustomerIdQuery request, CancellationToken cancellationToken)
            {
                var addressRepo = ServiceTool.ServiceProvider.GetService<IAddressRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var list = await addressRepo.GetAddressListWithCustomerIdInfo(request.CustomerId, cancellationToken);
                var result = mapper.Map<List<AddressDto>>(list);
                return ResponseMessage<List<AddressDto>>.Success(result);
            }
        }
    }
}