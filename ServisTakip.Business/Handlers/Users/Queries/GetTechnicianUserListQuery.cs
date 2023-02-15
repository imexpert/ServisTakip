using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Business.Handlers.Users.Queries
{
    public class GetTechnicianUserListQuery : IRequest<ResponseMessage<List<UserDto>>>
    {
        public class GetTechnicianUserListQueryHandler : IRequestHandler<GetTechnicianUserListQuery, ResponseMessage<List<UserDto>>>
        {
            public async Task<ResponseMessage<List<UserDto>>> Handle(GetTechnicianUserListQuery request, CancellationToken cancellationToken)
            {
                var userRepo = ServiceTool.ServiceProvider.GetService<IUserRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();
                var userList = await userRepo.GetTechnicianUserListAsync(cancellationToken);
                var result = mapper.Map<List<UserDto>>(userList);
                return ResponseMessage<List<UserDto>>.Success(result);
            }
        }
    }
}
