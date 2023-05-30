using ServisTakip.Entities.DTOs.Groups;

namespace ServisTakip.Business.Handlers.Groups.Queries
{
    public class GetGroupListQuery : IRequest<ResponseMessage<List<GroupDto>>>
    {
        public class GetGroupListQueryHandler : IRequestHandler<GetGroupListQuery, ResponseMessage<List<GroupDto>>>
        {
            public async Task<ResponseMessage<List<GroupDto>>> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
            {
                var groups = await Tools.GroupRepository.GetListAsync();
                var result = Tools.Mapper.Map<List<GroupDto>>(groups.Where(s=>s.Id != 2));
                return ResponseMessage<List<GroupDto>>.Success(result);
            }
        }
    }
}
