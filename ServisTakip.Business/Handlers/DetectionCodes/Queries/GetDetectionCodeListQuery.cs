using ServisTakip.Entities.DTOs.DetectionCodes;

namespace ServisTakip.Business.Handlers.DetectionCodes.Queries
{
    public class GetDetectionCodeListQuery : IRequest<ResponseMessage<List<DetectionCodeDto>>>
    {
        public class GetDetectionCodeListQueryHandler : IRequestHandler<GetDetectionCodeListQuery, ResponseMessage<List<DetectionCodeDto>>>
        {
            public async Task<ResponseMessage<List<DetectionCodeDto>>> Handle(GetDetectionCodeListQuery request, CancellationToken cancellationToken)
            {
                var detectionList = await Tools.DetectionCodeRepository.GetListAsync();
                var result = Tools.Mapper.Map<List<DetectionCodeDto>>(detectionList);
                return ResponseMessage<List<DetectionCodeDto>>.Success(result);
            }
        }
    }
}
