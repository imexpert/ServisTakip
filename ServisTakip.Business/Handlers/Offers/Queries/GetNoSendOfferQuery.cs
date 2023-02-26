using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Offers;
using ServisTakip.Entities.Enums;

namespace ServisTakip.Business.Handlers.Offers.Queries
{
    public class GetNoSendOfferQuery : IRequest<ResponseMessage<OfferDto>>
    {
        public long DeviceServiceId { get; set; }
        public class GetNoSendOfferQueryHandler : IRequestHandler<GetNoSendOfferQuery, ResponseMessage<OfferDto>>
        {
            public async Task<ResponseMessage<OfferDto>> Handle(GetNoSendOfferQuery request, CancellationToken cancellationToken)
            {
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var offer = await offerRepo.GetAsync(s =>
                    s.OfferStatus == (int)OfferStatusCodes.Gonderilmedi &&
                    s.DeviceServiceId == request.DeviceServiceId);
                var result = mapper.Map<OfferDto>(offer);
                return ResponseMessage<OfferDto>.Success(result);
            }
        }
    }
}
