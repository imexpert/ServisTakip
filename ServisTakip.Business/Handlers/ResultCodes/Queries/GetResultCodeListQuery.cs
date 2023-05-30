using ServisTakip.Entities.DTOs.ResultCodes;

namespace ServisTakip.Business.Handlers.ResultCodes.Queries
{
    public class GetResultCodeListQuery : IRequest<ResponseMessage<List<ResultCodeDto>>>
    {
        public class GetResultCodeListQueryHandler : IRequestHandler<GetResultCodeListQuery, ResponseMessage<List<ResultCodeDto>>>
        {
            public async Task<ResponseMessage<List<ResultCodeDto>>> Handle(GetResultCodeListQuery request, CancellationToken cancellationToken)
            {
                var resultCodeList = await Tools.ResultCodeRepository.GetListAsync();
                var result = Tools.Mapper.Map<List<ResultCodeDto>>(resultCodeList);
                return ResponseMessage<List<ResultCodeDto>>.Success(result);
            }
        }
    }
}
