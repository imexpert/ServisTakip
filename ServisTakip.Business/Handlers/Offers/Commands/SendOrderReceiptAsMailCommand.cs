using ServisTakip.Business.Handlers.DeviceServices.Queries;
using ServisTakip.Business.Handlers.MailSenders.Commands;
using ServisTakip.Entities.DTOs.Offers;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class SendOrderReceiptAsMailCommand : IRequest<ResponseMessage<CreateOfferDto>>
    {
        public MailModel Model { get; set; }
        public class SendOrderReceiptAsMailCommandHandler : IRequestHandler<SendOrderReceiptAsMailCommand, ResponseMessage<CreateOfferDto>>
        {
            public async Task<ResponseMessage<CreateOfferDto>> Handle(SendOrderReceiptAsMailCommand request, CancellationToken cancellationToken)
            {
                var orderReceiptResponse =
                    await Tools.Mediator.Send(new GetOrderReceiptReportQuery() { DeviceServiceId = request.Model.DeviceServiceId },
                        cancellationToken);

                if (orderReceiptResponse.IsSuccess)
                {
                    var mailResult = await Tools.Mediator.Send(new MailSenderCommand()
                    {
                        File = orderReceiptResponse.Data.Report,
                        Icerik = "Sipariş fişi ek'tedir.",
                        Konu = "Servisim - Sipariş Fişi",
                        AliciMail = request.Model.MailAddress
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
