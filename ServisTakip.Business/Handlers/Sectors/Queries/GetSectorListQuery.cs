using ServisTakip.Entities.DTOs.Sectors;

namespace ServisTakip.Business.Handlers.Sectors.Queries
{
    public class GetSectorListQuery : IRequest<ResponseMessage<List<SectorDto>>>
    {
        public class GetSectorListQueryHandler : IRequestHandler<GetSectorListQuery, ResponseMessage<List<SectorDto>>>
        {
            public async Task<ResponseMessage<List<SectorDto>>> Handle(GetSectorListQuery request, CancellationToken cancellationToken)
            {
                var sectors = await Tools.SectorRepository.GetListAsync(s => s.Status);
                var result = Tools.Mapper.Map<List<SectorDto>>(sectors);
                return ResponseMessage<List<SectorDto>>.Success(result);
            }
        }
    }
}
