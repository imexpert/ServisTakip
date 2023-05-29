namespace ServisTakip.Business.Handlers.Offers.Commands
{
    public class DeleteOfferCommand : IRequest<ResponseMessage<bool>>
    {
        public long Id{ get; set; }
        public class DeleteOfferCommandHandler : IRequestHandler<DeleteOfferCommand, ResponseMessage<bool>>
        {
            public async Task<ResponseMessage<bool>> Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
            {
                var offer = await Tools.OfferRepository.GetAsync(s => s.Id == request.Id);
                Tools.OfferRepository.Delete(offer);
                await Tools.OfferRepository.SaveChangesAsync();

                return ResponseMessage<bool>.Success();
            }
        }
    }
}
