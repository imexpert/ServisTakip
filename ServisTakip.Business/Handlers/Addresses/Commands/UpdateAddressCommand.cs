using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
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
                var addressRepo = ServiceTool.ServiceProvider.GetService<IAddressRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var customer = mapper.Map<Address>(request.Model);
                addressRepo.Update(customer);
                await addressRepo.SaveChangesAsync();
                return ResponseMessage<UpdateAddressDto>.Success();
            }
        }
    }
}
