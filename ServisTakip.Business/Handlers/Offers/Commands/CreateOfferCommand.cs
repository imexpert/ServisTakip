using ServisTakip.Entities.DTOs.Offers;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class CreateOfferCommand : IRequest<ResponseMessage<CreateOfferDto>>
    {
        public CreateOfferDto Model { get; set; }
        public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, ResponseMessage<CreateOfferDto>>
        {
            public async Task<ResponseMessage<CreateOfferDto>> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
            {
                var offer = Tools.Mapper.Map<Offer>(request.Model);
                offer.OfferStatus = (int)OfferStatusCodes.Gonderilmedi;
                Tools.OfferRepository.Add(offer);
                await Tools.OfferRepository.SaveChangesAsync();

                return ResponseMessage<CreateOfferDto>.Success();
            }
        }
    }
}
