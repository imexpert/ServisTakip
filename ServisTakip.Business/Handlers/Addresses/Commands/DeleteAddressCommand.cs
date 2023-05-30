using ServisTakip.Entities.DTOs.Addresses;

namespace ServisTakip.Business.Handlers.Addresses.Commands
{
    public class DeleteAddressCommand : IRequest<ResponseMessage<CreateAddressDto>>
    {
        public long Id { get; set; }
        public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, ResponseMessage<CreateAddressDto>>
        {
            public async Task<ResponseMessage<CreateAddressDto>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
            {
                var customer = await Tools.AddressRepository.GetAsync(s => s.Id == request.Id);
                Tools.AddressRepository.Delete(customer);
                await Tools.AddressRepository.SaveChangesAsync();
                return ResponseMessage<CreateAddressDto>.Success();
            }
        }
    }
}
