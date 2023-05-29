using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Business.Handlers.Users.Queries
{
    public class GetUserListQuery : IRequest<ResponseMessage<List<UserDto>>>
    {
        public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, ResponseMessage<List<UserDto>>>
        {
            public async Task<ResponseMessage<List<UserDto>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {
                var userList = await Tools.UserRepository.GetUserListAsync(cancellationToken);
                var result = Tools.Mapper.Map<List<UserDto>>(userList);
                return ResponseMessage<List<UserDto>>.Success(result);
            }
        }
    }
}
