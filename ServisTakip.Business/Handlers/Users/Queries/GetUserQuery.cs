using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Business.Handlers.Users.Queries
{
    public class GetUserQuery : IRequest<ResponseMessage<UserDto>>
    {
        public long Id { get; set; }
        public class GetUserQueryHandler : IRequestHandler<GetUserQuery, ResponseMessage<UserDto>>
        {
            public async Task<ResponseMessage<UserDto>> Handle(GetUserQuery request, CancellationToken cancellationToken)
            {
                var userList = await Tools.UserRepository.GetUserAsync(request.Id,cancellationToken);
                var result = Tools.Mapper.Map<UserDto>(userList);
                return ResponseMessage<UserDto>.Success(result);
            }
        }
    }
}
