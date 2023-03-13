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
    public class DeleteAddressCommand : IRequest<ResponseMessage<CreateAddressDto>>
    {
        public long Id { get; set; }
        public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand, ResponseMessage<CreateAddressDto>>
        {
            public async Task<ResponseMessage<CreateAddressDto>> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
            {
                var addressRepo = ServiceTool.ServiceProvider.GetService<IAddressRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var customer = await addressRepo.GetAsync(s => s.Id == request.Id);
                addressRepo.Delete(customer);
                await addressRepo.SaveChangesAsync();
                return ResponseMessage<CreateAddressDto>.Success();
            }
        }
    }
}
