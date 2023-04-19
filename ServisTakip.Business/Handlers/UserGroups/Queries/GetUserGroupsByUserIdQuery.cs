using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
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
                var userGroupRepo = ServiceTool.ServiceProvider.GetService<IUserGroupRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var userGroupList = await userGroupRepo.GetUserGroupsByUserId(request.UserId, cancellationToken);
                var result = mapper.Map<List<UserGroupDto>>(userGroupList);
                return ResponseMessage<List<UserGroupDto>>.Success(result);
            }
        }
    }
}