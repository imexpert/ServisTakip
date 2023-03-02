using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Business.Handlers.DeviceServices.Queries;
using ServisTakip.Business.Handlers.MailSenders.Commands;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Offers;
using ServisTakip.Entities.Enums;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class SendOrderReceiptAsMailCommand : IRequest<ResponseMessage<CreateOfferDto>>
    {
        public MailModel Model { get; set; }
        public class SendOrderReceiptAsMailCommandHandler : IRequestHandler<SendOrderReceiptAsMailCommand, ResponseMessage<CreateOfferDto>>
        {
            public async Task<ResponseMessage<CreateOfferDto>> Handle(SendOrderReceiptAsMailCommand request, CancellationToken cancellationToken)
            {
                var mediator = ServiceTool.ServiceProvider.GetService<IMediator>();
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();

                var orderReceiptResponse =
                    await mediator.Send(new GetOrderReceiptReportQuery() { DeviceServiceId = request.Model.DeviceServiceId },
                        cancellationToken);

                if (orderReceiptResponse.IsSuccess)
                {
                    var mailResult = await mediator.Send(new MailSenderCommand()
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
