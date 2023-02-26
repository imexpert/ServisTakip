using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Offers;
using ServisTakip.Entities.Enums;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class SendOfferCommand : IRequest<ResponseMessage<CreateOfferDto>>
    {
        public CreateOfferDto Model { get; set; }
        public class SendOfferCommandHandler : IRequestHandler<SendOfferCommand, ResponseMessage<CreateOfferDto>>
        {
            public async Task<ResponseMessage<CreateOfferDto>> Handle(SendOfferCommand request, CancellationToken cancellationToken)
            {
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var offer = await offerRepo.GetAsync(s => s.Id == request.Model.Id);
                offer.OfferStatus = (int)OfferStatusCodes.Gonderildi;
                offerRepo.Update(offer);
                await offerRepo.SaveChangesAsync();

                return ResponseMessage<CreateOfferDto>.Success();
            }
        }
    }
}
