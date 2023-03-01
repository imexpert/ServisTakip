using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Offers;
using ServisTakip.Entities.Enums;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class SendOfferCommand : IRequest<ResponseMessage<CreateOfferDto>>
    {
        public OfferDto Model { get; set; }
        public class SendOfferCommandHandler : IRequestHandler<SendOfferCommand, ResponseMessage<CreateOfferDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<CreateOfferDto>> Handle(SendOfferCommand request, CancellationToken cancellationToken)
            {
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();
                var mediator = ServiceTool.ServiceProvider.GetService<IMediator>();

                var offer = await offerRepo.GetAsync(s => s.DeviceServiceId == request.Model.DeviceServiceId && s.OfferStatus == ((int)OfferStatusCodes.Gonderilmedi));
                offer.OfferStatus = (int)OfferStatusCodes.Gonderildi;
                offerRepo.Update(offer);
                await offerRepo.SaveChangesAsync();

                var deviceService = await deviceServiceRepo.GetAsync(s => s.Id == request.Model.DeviceServiceId);
                deviceService.StatusCode = ((int)StatusCodes.TeklifGonderildi);
                deviceServiceRepo.Update(deviceService);
                await deviceServiceRepo.SaveChangesAsync();

                var sendOfferResponse = await mediator.Send(new SendOfferAsMailCommand() { DeviceServiceId = request.Model.DeviceServiceId.Value });

                return ResponseMessage<CreateOfferDto>.Success();
            }
        }
    }
}
