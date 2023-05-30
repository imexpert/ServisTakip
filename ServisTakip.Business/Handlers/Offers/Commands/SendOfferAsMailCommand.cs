using ServisTakip.Business.Handlers.MailSenders.Commands;
using ServisTakip.Entities.DTOs.Offers;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class SendOfferAsMailCommand : IRequest<ResponseMessage<CreateOfferDto>>
    {
        public long DeviceServiceId { get; set; }
        public class SendOfferAsMailCommandHandler : IRequestHandler<SendOfferAsMailCommand, ResponseMessage<CreateOfferDto>>
        {
            public async Task<ResponseMessage<CreateOfferDto>> Handle(SendOfferAsMailCommand request, CancellationToken cancellationToken)
            {
                var offer = await Tools.OfferRepository.GetOfferAsync(request.DeviceServiceId, cancellationToken);

                var reportResponse = await Tools.Mediator.Send(new DownloadOfferCommand()
                    { DeviceServiceId = request.DeviceServiceId }, cancellationToken);

                if (reportResponse.IsSuccess)
                {
                    var mailResult = await Tools.Mediator.Send(new MailSenderCommand()
                    {
                        File = reportResponse.Data.Report,
                        Icerik = "Teklif ek'tedir.",
                        Konu = "Servisim - Teklif Raporu",
                        AliciMail = offer.OfferSendEmail
                    }, cancellationToken);

                    if (mailResult.IsSuccess)
                    {
                        return ResponseMessage<CreateOfferDto>.Success();
                    }

                    return ResponseMessage<CreateOfferDto>.Fail("Mail gönderilemedi.");
                }

                return ResponseMessage<CreateOfferDto>.Fail("Rapor oluşturulamadı.");
            }
        }
    }
}
