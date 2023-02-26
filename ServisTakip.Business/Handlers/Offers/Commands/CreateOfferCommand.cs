using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.Concrete;
using ServisTakip.Entities.DTOs.Offers;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class CreateOfferCommand : IRequest<ResponseMessage<CreateOfferDto>>
    {
        public CreateOfferDto Model { get; set; }
        public class CreateOfferCommandHandler : IRequestHandler<CreateOfferCommand, ResponseMessage<CreateOfferDto>>
        {
            public async Task<ResponseMessage<CreateOfferDto>> Handle(CreateOfferCommand request, CancellationToken cancellationToken)
            {
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var offer = mapper.Map<Offer>(request.Model);
                offerRepo.Add(offer);
                await offerRepo.SaveChangesAsync();

                return ResponseMessage<CreateOfferDto>.Success();
            }
        }
    }
}
