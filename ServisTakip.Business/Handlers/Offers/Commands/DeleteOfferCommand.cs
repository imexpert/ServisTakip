using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;

namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class DeleteOfferCommand : IRequest<ResponseMessage<bool>>
    {
        public long Id{ get; set; }
        public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, ResponseMessage<bool>>
        {
            public async Task<ResponseMessage<bool>> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
            {
                var offerRepo = ServiceTool.ServiceProvider.GetService<IOfferRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var offer = await offerRepo.GetAsync(s => s.Id == request.Id);
                offerRepo.Delete(offer);
                await offerRepo.SaveChangesAsync();

                return ResponseMessage<bool>.Success();
            }
        }
    }
}
