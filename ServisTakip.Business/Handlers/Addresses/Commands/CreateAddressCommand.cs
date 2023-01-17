using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Addresses;
using ServisTakip.Entities.DTOs.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServisTakip.Business.Handlers.Addresses.Commands
{
    public class CreateAddressCommand : IRequest<ResponseMessage<CreateAddressDto>>
    {
        public CreateAddressDto Model { get; set; }
        public class CreateCustomerAddressCommandHandler : IRequestHandler<CreateAddressCommand, ResponseMessage<CreateAddressDto>>
        {
            public async Task<ResponseMessage<CreateAddressDto>> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
            {
                var addressRepo = ServiceTool.ServiceProvider.GetService<IAddressRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var customer = mapper.Map<Address>(request.Model);
                customer.Status = true;

                addressRepo.Add(customer);
                await addressRepo.SaveChangesAsync();
                return ResponseMessage<CreateAddressDto>.Success();
            }
        }
    }
}
