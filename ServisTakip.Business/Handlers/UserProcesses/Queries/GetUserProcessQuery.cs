using ServisTakip.Entities.DTOs.UserProcesses;

namespace ServisTakip.Business.Handlers.UserProcesses.Queries
{
    public class GetUserProcessQuery : IRequest<UserProcessDto>
    {
        public class GetUserProcessQueryHandler : IRequestHandler<GetUserProcessQuery, UserProcessDto>
        {
            public async Task<UserProcessDto> Handle(GetUserProcessQuery request, CancellationToken cancellationToken)
            {
                var userProcess = await Tools.UserProcessRepository.GetAsync(s => s.UserId == Utils.UserId);
                return Tools.Mapper.Map<UserProcessDto>(userProcess);
            }
        }
    }
}