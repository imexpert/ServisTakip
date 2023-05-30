using ServisTakip.Business.Handlers.Companies.Queries;
using ServisTakip.Business.Handlers.DeviceServices.Queries;
using ServisTakip.Entities.DTOs.Offers;

namespace ServisTakip.Business.Handlers.Offers.Queries
{
    public class GetNoSendOfferQuery : IRequest<ResponseMessage<OfferDto>>
    {
        public long DeviceServiceId { get; set; }
        public class GetNoSendOfferQueryHandler : IRequestHandler<GetNoSendOfferQuery, ResponseMessage<OfferDto>>
        {
            public async Task<ResponseMessage<OfferDto>> Handle(GetNoSendOfferQuery request, CancellationToken cancellationToken)
            {
                Offer offer = await Tools.OfferRepository.GetAsync(s =>
                    s.OfferStatus == (int)OfferStatusCodes.Gonderilmedi &&
                    s.DeviceServiceId == request.DeviceServiceId);

                if (offer == null || offer.Id == 0)
                {
                    offer = new Offer();

                    var companyResponse = await Tools.Mediator.Send(new GetCompanyQuery(), cancellationToken);
                    if (companyResponse.IsSuccess)
                    {
                        var company = companyResponse.Data;
                        offer.Title = company.Title;
                        offer.Phone = company.Phone;
                        offer.Fax= company.Fax;
                        offer.AuthorizeFullname= company.AuthorizeFullname;
                        offer.Address= company.Address;
                    }

                    var deviceServiceResponse = await Tools.Mediator.Send(new GetDeviceServiceQuery() { DeviceServiceId = request.DeviceServiceId });

                    if (deviceServiceResponse.IsSuccess)
                    {
                        var deviceService = deviceServiceResponse.Data;
                        offer.OfferCompanyTitle = deviceService.Device.Address.Customer.Title;
                        offer.OfferAuthorizeFullname = deviceService.Device.Address.AuthorizedName;
                        offer.OfferPhone = deviceService.Device.Address.AuthorizedPhone;
                        offer.OfferSendEmail = deviceService.Device.Address.AuthorizedEmail;
                    }
                }

                var result = Tools.Mapper.Map<OfferDto>(offer);
                return ResponseMessage<OfferDto>.Success(result);
            }
        }
    }
}
