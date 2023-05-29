using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Entities.DTOs.Offers;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class SendOfferAgainCommand : IRequest<ResponseMessage<CreateOfferDto>>
    {
        public OfferDto Model { get; set; }
        public class SendOfferAgainCommandHandler : IRequestHandler<SendOfferAgainCommand, ResponseMessage<CreateOfferDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<CreateOfferDto>> Handle(SendOfferAgainCommand request, CancellationToken cancellationToken)
            {
                await Tools.Mediator.Send(new SendOfferAsMailCommand() { DeviceServiceId = request.Model.DeviceServiceId.Value }, cancellationToken);

                return ResponseMessage<CreateOfferDto>.Success();
            }
        }
    }
}
