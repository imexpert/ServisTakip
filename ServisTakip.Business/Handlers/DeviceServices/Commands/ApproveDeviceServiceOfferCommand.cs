using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Entities.DTOs.Offers;

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
                var deviceService = await Tools.DeviceServiceRepository.GetAsync(s => s.Id == request.Model.DeviceServiceId);
                deviceService.StatusCode = (int)StatusCodes.ParcaDegisecekTeknisyensiz;
                Tools.DeviceServiceRepository.Update(deviceService);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                var offer = await Tools.OfferRepository.GetAsync(s =>
                    s.DeviceServiceId == deviceService.Id && s.OfferStatus == (int)OfferStatusCodes.Gonderildi);

                offer.OfferStatus = (int)OfferStatusCodes.KabulEdildi;
                Tools.OfferRepository.Update(offer);
                await Tools.OfferRepository.SaveChangesAsync();

                return ResponseMessage<OfferDto>.Success(request.Model);
            }
        }
    }
}
