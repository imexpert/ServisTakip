using ServisTakip.Entities.DTOs.OfferSubjectCodes;

namespace ServisTakip.Business.Handlers.OfferSubjectCodes.Queries
{
    public class GetOfferSubjectCodeQuery : IRequest<ResponseMessage<List<OfferSubjectCodeDto>>>
    {
        public class GetOfferSubjectCodeQueryHandler  :IRequestHandler<GetOfferSubjectCodeQuery, ResponseMessage<List<OfferSubjectCodeDto>>>
        {
            public async Task<ResponseMessage<List<OfferSubjectCodeDto>>> Handle(GetOfferSubjectCodeQuery request, CancellationToken cancellationToken)
            {
                var offerSubjectCodes = await Tools.OfferSubjectCodeRepository.GetListAsync();
                var result = Tools.Mapper.Map<List<OfferSubjectCodeDto>>(offerSubjectCodes);
                return ResponseMessage<List<OfferSubjectCodeDto>>.Success(result);
            }
        }
    }
}
