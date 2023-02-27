using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Business.Handlers.Companies.Queries;
using ServisTakip.Business.Handlers.DeviceServices.Queries;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
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
                var mediator = ServiceTool.ServiceProvider.GetService<IMediator>();

                Offer offer = await offerRepo.GetAsync(s =>
                    s.OfferStatus == (int)OfferStatusCodes.Gonderilmedi &&
                    s.DeviceServiceId == request.DeviceServiceId);

                if (offer == null || offer.Id == 0)
                {
                    offer = new Offer();

                    var companyResponse = await mediator.Send(new GetCompanyQuery(), cancellationToken);
                    if (companyResponse.IsSuccess)
                    {
                        var company = companyResponse.Data;
                        offer.Title = company.Title;
                        offer.Phone = company.Phone;
                        offer.Fax= company.Fax;
                        offer.AuthorizeFullname= company.AuthorizeFullname;
                        offer.Address= company.Address;
                    }

                    var deviceServiceResponse = await mediator.Send(new GetDeviceServiceQuery() { DeviceServiceId = request.DeviceServiceId });

                    if (deviceServiceResponse.IsSuccess)
                    {
                        var deviceService = deviceServiceResponse.Data;
                        offer.OfferCompanyTitle = deviceService.Device.Address.Customer.Title;
                        offer.OfferAuthorizeFullname = deviceService.Device.Address.AuthorizedName;
                        offer.OfferPhone = deviceService.Device.Address.AuthorizedPhone;
                        offer.OfferSendEmail = deviceService.Device.Address.AuthorizedEmail;
                    }
                }

                var result = mapper.Map<OfferDto>(offer);
                return ResponseMessage<OfferDto>.Success(result);
            }
        }
    }
}
