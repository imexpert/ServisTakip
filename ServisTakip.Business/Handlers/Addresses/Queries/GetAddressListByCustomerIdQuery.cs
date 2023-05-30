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
                var list = await Tools.AddressRepository.GetAddressListWithCustomerIdInfo(request.CustomerId, cancellationToken);
                var result = Tools.Mapper.Map<List<AddressDto>>(list);
                return ResponseMessage<List<AddressDto>>.Success(result);
            }
        }
    }
}