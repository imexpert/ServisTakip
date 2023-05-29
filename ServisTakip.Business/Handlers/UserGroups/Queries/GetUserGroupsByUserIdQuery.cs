using ServisTakip.Entities.DTOs.UserGroups;

namespace ServisTakip.Business.Handlers.UserGroups.Queries
{
    public class GetUserGroupsByUserIdQuery : IRequest<ResponseMessage<List<UserGroupDto>>>
    {
        public long UserId { get; set; }
        public class GetUserGroupsByUserIdQueryHandler : IRequestHandler<GetUserGroupsByUserIdQuery, ResponseMessage<List<UserGroupDto>>>
        {
            public async Task<ResponseMessage<List<UserGroupDto>>> Handle(GetUserGroupsByUserIdQuery request, CancellationToken cancellationToken)
            {
                var userGroupList = await Tools.UserGroupRepository.GetUserGroupsByUserId(request.UserId, cancellationToken);
                var result = Tools.Mapper.Map<List<UserGroupDto>>(userGroupList);
                return ResponseMessage<List<UserGroupDto>>.Success(result);
            }
        }
    }
}