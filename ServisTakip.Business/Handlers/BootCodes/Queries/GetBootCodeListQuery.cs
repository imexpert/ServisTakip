using ServisTakip.Entities.DTOs.BootCodes;

namespace ServisTakip.Business.Handlers.BootCodes.Queries
{
    public class GetBootCodeListQuery : IRequest<ResponseMessage<List<BootCodeDto>>>
    {
        public class GetBootCodeListQueryHandler : IRequestHandler<GetBootCodeListQuery, ResponseMessage<List<BootCodeDto>>>
        {
            public async Task<ResponseMessage<List<BootCodeDto>>> Handle(GetBootCodeListQuery request, CancellationToken cancellationToken)
            {
                var bootCodeList = await Tools.BootCodeRepository.GetListAsync();
                var result = Tools.Mapper.Map<List<BootCodeDto>>(bootCodeList);
                return ResponseMessage<List<BootCodeDto>>.Success(result);
            }
        }
    }
}
