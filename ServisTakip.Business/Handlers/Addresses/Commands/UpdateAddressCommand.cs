using ServisTakip.Entities.DTOs.Addresses;

namespace ServisTakip.Business.Handlers.Addresses.Commands
{
    public class UpdateAddressCommand : IRequest<ResponseMessage<UpdateAddressDto>>
    {
        public UpdateAddressDto Model { get; set; }
        public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, ResponseMessage<UpdateAddressDto>>
        {
            public async Task<ResponseMessage<UpdateAddressDto>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
            {
                var customer = Tools.Mapper.Map<Address>(request.Model);
                Tools.AddressRepository.Update(customer);
                await Tools.AddressRepository.SaveChangesAsync();
                return ResponseMessage<UpdateAddressDto>.Success();
            }
        }
    }
}
