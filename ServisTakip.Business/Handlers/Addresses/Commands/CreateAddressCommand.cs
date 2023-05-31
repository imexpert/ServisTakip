using ServisTakip.Business.Handlers.UserProcesses.Commands;
using ServisTakip.Entities.DTOs.Addresses;
using ServisTakip.Entities.DTOs.UserProcesses;

namespace ServisTakip.Business.Handlers.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<ResponseMessage<CreateAddressDto>>
    {
        public CreateAddressDto Model { get; set; }
        public class CreateCustomerAddressCommandHandler : IRequestHandler<CreateAddressCommand, ResponseMessage<CreateAddressDto>>
        {
            public async Task<ResponseMessage<CreateAddressDto>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
            {
                var address = Tools.Mapper.Map<Address>(request.Model);
                address.Status = true;

                Tools.AddressRepository.Add(address);
                await Tools.AddressRepository.SaveChangesAsync();

                #region Kullanıcı İşlem Bilgisi Ekleme
                UpdateUserProcessDto userProcess = new UpdateUserProcessDto()
                {
                    AddressId = address.Id,
                    CustomerId = address.CustomerId,
                };
                await Tools.Mediator.Send(new UpdateUserProcessCommand() { Model = userProcess }, cancellationToken);
                #endregion

                return ResponseMessage<CreateAddressDto>.Success();
            }
        }
    }
}
