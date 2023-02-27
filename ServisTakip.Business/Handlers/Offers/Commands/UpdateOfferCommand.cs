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
    public class UpdateOfferCommand : IRequest<ResponseMessage<CreateOfferDto>>
    {
        public CreateOfferDto Model { get; set; }
        public class UpdateOfferCommandHandler : IRequestHandler<UpdateOfferCommand, ResponseMessage<CreateOfferDto>>
        {
            public async Task<ResponseMessage<CreateOfferDto>> Handle(UpdateOfferCommand request, CancellationToken cancellationToken)
            {
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var offer = await offerRepo.GetAsync(s => s.Id == request.Model.Id);

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

                offerRepo.Update(offer);
                await offerRepo.SaveChangesAsync();

                return ResponseMessage<CreateOfferDto>.Success();
            }
        }
    }
}
