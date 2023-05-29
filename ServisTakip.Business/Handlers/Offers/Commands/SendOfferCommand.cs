using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Entities.DTOs.Offers;

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
                var offer = await Tools.OfferRepository.GetAsync(s => s.DeviceServiceId == request.Model.DeviceServiceId && s.OfferStatus == ((int)OfferStatusCodes.Gonderilmedi));
                offer.OfferStatus = (int)OfferStatusCodes.Gonderildi;
                Tools.OfferRepository.Update(offer);
                await Tools.OfferRepository.SaveChangesAsync();

                var deviceService = await Tools.DeviceServiceRepository.GetAsync(s => s.Id == request.Model.DeviceServiceId);
                deviceService.StatusCode = ((int)StatusCodes.TeklifGonderildi);
                Tools.DeviceServiceRepository.Update(deviceService);
                await Tools.DeviceServiceRepository.SaveChangesAsync();

                var sendOfferResponse = await Tools.Mediator.Send(new SendOfferAsMailCommand() { DeviceServiceId = request.Model.DeviceServiceId.Value });

                return ResponseMessage<CreateOfferDto>.Success();
            }
        }
    }
}
