using ServisTakip.Entities.DTOs.Addresses;

namespace ServisTakip.Business.Handlers.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<ResponseMessage<CreateAddressDto>>
    {
        public CreateAddressDto Model { get; set; }
        public class CreateCustomerAddressCommandHandler : IRequestHandler<CreateAddressCommand, ResponseMessage<CreateAddressDto>>
        {
            public async Task<ResponseMessage<CreateAddressDto>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
            {
                var customer = Tools.Mapper.Map<Address>(request.Model);
                customer.Status = true;

                Tools.AddressRepository.Add(customer);
                await Tools.AddressRepository.SaveChangesAsync();
                return ResponseMessage<CreateAddressDto>.Success();
            }
        }
    }
}
