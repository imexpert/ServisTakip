using ServisTakip.Entities.DTOs.Addresses;

namespace ServisTakip.Business.Handlers.Addresses.Queries
{
    public class GetAddressByIdQuery : IRequest<ResponseMessage<AddressDto>>
    {
        public long Id { get; set; }
        public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQuery, ResponseMessage<AddressDto>>
        {
            public async Task<ResponseMessage<AddressDto>> Handle(GetAddressByIdQuery request, CancellationToken cancellationToken)
            {
                var address = await Tools.AddressRepository.GetAddressInfo(request.Id);
                var result = Tools.Mapper.Map<AddressDto>(address);
                return ResponseMessage<AddressDto>.Success(result);
            }
        }
    }
}