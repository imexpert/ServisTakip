using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
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
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();
                var deviceServiceRepo = ServiceTool.ServiceProvider.GetService<IDeviceServiceRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();
                var mediator = ServiceTool.ServiceProvider.GetService<IMediator>();
                
                var sendOfferResponse = await mediator.Send(new SendOfferAsMailCommand() { DeviceServiceId = request.Model.DeviceServiceId.Value }, cancellationToken);

                return ResponseMessage<CreateOfferDto>.Success();
            }
        }
    }
}
