using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Business.Handlers.Users.Queries
{
    public class GetTechnicianUserListQuery : IRequest<ResponseMessage<List<UserDto>>>
    {
        public class GetTechnicianUserListQueryHandler : IRequestHandler<GetTechnicianUserListQuery, ResponseMessage<List<UserDto>>>
        {
            public async Task<ResponseMessage<List<UserDto>>> Handle(GetTechnicianUserListQuery request, CancellationToken cancellationToken)
            {
                var userList = await Tools.UserRepository.GetTechnicianUserListAsync(cancellationToken);
                var result = Tools.Mapper.Map<List<UserDto>>(userList);
                return ResponseMessage<List<UserDto>>.Success(result);
            }
        }
    }
}
