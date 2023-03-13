using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
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
                var addressRepo = ServiceTool.ServiceProvider.GetService<IAddressRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var address = await addressRepo.GetAddressInfo(request.Id);
                var result = mapper.Map<AddressDto>(address);
                return ResponseMessage<AddressDto>.Success(result);
            }
        }
    }
}