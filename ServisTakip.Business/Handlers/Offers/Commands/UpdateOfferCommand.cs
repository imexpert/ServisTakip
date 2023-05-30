using ServisTakip.Entities.DTOs.Offers;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class UpdateOfferCommand : IRequest<ResponseMessage<CreateOfferDto>>
    {
        public CreateOfferDto Model { get; set; }
        public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, ResponseMessage<CreateOfferDto>>
        {
            public async Task<ResponseMessage<CreateOfferDto>> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
            {
                var offer = await Tools.OfferRepository.GetAsync(s => s.Id == request.Model.Id);

                offer.DeviceServiceId = request.Model.DeviceServiceId;
                offer.OfferSubjectCodeId = request.Model.OfferSubjectCodeId;
                offer.OfferSendEmail = request.Model.OfferSendEmail;
                offer.Title = request.Model.Title;
                offer.Address = request.Model.Address;
                offer.AuthorizeFullname = request.Model.AuthorizeFullname;
                offer.AuthorizeMail = request.Model.AuthorizeMail;
                offer.Phone = request.Model.Phone;
                offer.Fax = request.Model.Fax;
                offer.OfferCompanyTitle = request.Model.OfferCompanyTitle;
                offer.OfferAuthorizeFullname = request.Model.OfferAuthorizeFullname;
                offer.OfferPhone = request.Model.OfferPhone;
                offer.OfferDate = request.Model.OfferDate;
                offer.OfferStatus = request.Model.OfferStatus;
                offer.DiscountRate = request.Model.DiscountRate;
                offer.OfferStatus = request.Model.OfferStatus;

                Tools.OfferRepository.Update(offer);
                await Tools.OfferRepository.SaveChangesAsync();

                return ResponseMessage<CreateOfferDto>.Success();
            }
        }
    }
}
