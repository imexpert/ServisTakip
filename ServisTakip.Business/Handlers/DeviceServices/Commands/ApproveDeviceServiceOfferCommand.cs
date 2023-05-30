using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.DTOs.Offers;
using ServisTakip.Entities.Enums;

namespace ServisTakip.Business.Handlers.DeviceServices.Commands
{
    public class ApproveDeviceServiceOfferCommand : IRequest<ResponseMessage<OfferDto>>
    {
        public OfferDto Model { get; set; }
        public class ApproveDeviceServiceOfferCommandHandler : IRequestHandler<ApproveDeviceServiceOfferCommand, ResponseMessage<OfferDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<OfferDto>> Handle(ApproveDeviceServiceOfferCommand request, CancellationToken cancellationToken)
            {
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();

                var deviceService = await deviceServiceRepo.GetAsync(s => s.Id == request.Model.DeviceServiceId);
                deviceService.StatusCode = (int)StatusCodes.ParcaDegisecekTeknisyensiz;
                deviceServiceRepo.Update(deviceService);
                await deviceServiceRepo.SaveChangesAsync();

                var offer = await offerRepo.GetAsync(s =>
                    s.DeviceServiceId == deviceService.Id && s.OfferStatus == (int)OfferStatusCodes.Gonderildi);

                offer.OfferStatus = (int)OfferStatusCodes.KabulEdildi;
                offerRepo.Update(offer);
                await offerRepo.SaveChangesAsync();

                return ResponseMessage<OfferDto>.Success(request.Model);
            }
        }
    }
}
