using ServisTakip.Entities.DTOs.User;
using ServisTakip.Core.Aspects.Autofac.Transaction;

namespace ServisTakip.Business.Handlers.Users.Commands
{
    public class DeleteUserCommand : IRequest<ResponseMessage<DeleteUserDto>>
    {
        public DeleteUserDto Model { get; set; }
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseMessage<DeleteUserDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<DeleteUserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var userGroups = await Tools.UserGroupRepository.GetListAsync(s => s.UserId == request.Model.Id);
                Tools.UserGroupRepository.DeleteRange(userGroups.ToList());
                await Tools.UserGroupRepository.SaveChangesAsync();

                var user = await Tools.UserRepository.GetAsync(s => s.Id == request.Model.Id);
                Tools.UserRepository.Delete(user);

                var result = Tools.Mapper.Map<DeleteUserDto>(user);

                await Tools.UserRepository.SaveChangesAsync();

                return ResponseMessage<DeleteUserDto>.Success(result);
            }
        }
    }
}
