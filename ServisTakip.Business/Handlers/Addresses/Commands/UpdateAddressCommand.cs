using ServisTakip.Business.Handlers.UserProcesses.Commands;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Addresses;
using ServisTakip.Entities.DTOs.UserProcesses;

namespace ServisTakip.Business.Handlers.Addresses.Commands
{
    public class UpdateAddressCommand : IRequest<ResponseMessage<UpdateAddressDto>>
    {
        public UpdateAddressDto Model { get; set; }
        public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand, ResponseMessage<UpdateAddressDto>>
        {
            public async Task<ResponseMessage<UpdateAddressDto>> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
            {
                var address = Tools.Mapper.Map<Address>(request.Model);
                Tools.AddressRepository.Update(address);
                await Tools.AddressRepository.SaveChangesAsync();

                #region Kullanıcı İşlem Bilgisi Ekleme
                UpdateUserProcessDto userProcess = new UpdateUserProcessDto()
                {
                    AddressId = address.Id,
                    CustomerId = address.CustomerId,
                };
                await Tools.Mediator.Send(new UpdateUserProcessCommand() { Model = userProcess }, cancellationToken);
                #endregion

                return ResponseMessage<UpdateAddressDto>.Success();
            }
        }
    }
}
