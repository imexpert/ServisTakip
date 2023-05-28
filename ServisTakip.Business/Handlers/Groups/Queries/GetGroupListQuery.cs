using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.Groups;

namespace ServisTakip.Business.Handlers.Groups.Queries
{
    public class GetGroupListQuery : IRequest<ResponseMessage<List<GroupDto>>>
    {
        public class GetGroupListQueryHandler : IRequestHandler<GetGroupListQuery, ResponseMessage<List<GroupDto>>>
        {
            public async Task<ResponseMessage<List<GroupDto>>> Handle(GetGroupListQuery request, CancellationToken cancellationToken)
            {
                var groupRepo = ServiceTool.ServiceProvider.GetService<IGroupRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var groups = await groupRepo.GetListAsync();
                var result = mapper.Map<List<GroupDto>>(groups.Where(s=>s.Id != 2));
                return ResponseMessage<List<GroupDto>>.Success(result);
            }
        }
    }
}
