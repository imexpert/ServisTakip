using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
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
                var userRepo = ServiceTool.ServiceProvider.GetService<IUserRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();
                var userList = await userRepo.GetUserAsync(request.Id,cancellationToken);
                var result = mapper.Map<UserDto>(userList);
                return ResponseMessage<UserDto>.Success(result);
            }
        }
    }
}
