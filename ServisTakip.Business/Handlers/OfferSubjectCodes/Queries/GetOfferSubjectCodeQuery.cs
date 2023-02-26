using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.OfferSubjectCodes;

namespace ServisTakip.Business.Handlers.OfferSubjectCodes.Queries
{
    public class GetOfferSubjectCodeQuery : IRequest<ResponseMessage<List<OfferSubjectCodeDto>>>
    {
        public class GetOfferSubjectCodeQueryHandler  :IRequestHandler<GetOfferSubjectCodeQuery, ResponseMessage<List<OfferSubjectCodeDto>>>
        {
            public async Task<ResponseMessage<List<OfferSubjectCodeDto>>> Handle(GetOfferSubjectCodeQuery request, CancellationToken cancellationToken)
            {
                var offerSubjectCodeRepo = ServiceTool.ServiceProvider.GetService<IOfferSubjectCodeRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var offerSubjectCodes = await offerSubjectCodeRepo.GetListAsync();
                var result = mapper.Map<List<OfferSubjectCodeDto>>(offerSubjectCodes);
                return ResponseMessage<List<OfferSubjectCodeDto>>.Success(result);
            }
        }
    }
}
