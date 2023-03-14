using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Business.Handlers.MailSenders.Commands;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
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
                var mediator = ServiceTool.ServiceProvider.GetService<IMediator>();
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();

                var offer = await offerRepo.GetOfferAsync(request.DeviceServiceId, cancellationToken);

                var reportResponse = await mediator.Send(new DownloadOfferCommand()
                    { DeviceServiceId = request.DeviceServiceId }, cancellationToken);

                if (reportResponse.IsSuccess)
                {
                    var mailResult = await mediator.Send(new MailSenderCommand()
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
