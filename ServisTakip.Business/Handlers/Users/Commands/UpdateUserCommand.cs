using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Entities.DTOs.User;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace ServisTakip.Business.Handlers.Users.Commands
{
    public class UpdateUserCommand : IRequest<ResponseMessage<UpdateUserDto>>
    {
        public UpdateUserDto Model { get; set; }
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseMessage<UpdateUserDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<UpdateUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyUser = await Tools.UserRepository.GetAsync(u => u.Email == request.Model.Email && u.Id != request.Model.Id);
                if (isThereAnyUser != null)
                    return ResponseMessage<UpdateUserDto>.Fail(StatusCodes.Status400BadRequest, "Bu kullanıcı adı zaten eklenmiş.");

                var user = await Tools.UserRepository.GetAsync(s => s.Id == request.Model.Id);

                user.CompanyId = Utils.CompanyId;
                if (request.Model.Avatar is { Length: > 0 })
                    user.Avatar = request.Model.Avatar;
                user.Firstname = request.Model.Firstname;
                user.Lastname = request.Model.Lastname;
                user.Gender = request.Model.Gender;
                user.Email = request.Model.Email;
                user.Status = request.Model.Status;

                Tools.UserRepository.Update(user);
                await Tools.UserRepository.SaveChangesAsync();

                var userGroups = await Tools.UserGroupRepository.GetListAsync(s => s.UserId == request.Model.Id);
                Tools.UserGroupRepository.DeleteRange(userGroups.ToList());
                await Tools.UserGroupRepository.SaveChangesAsync();

                List<UserGroup> newGroup = new List<UserGroup>();
                if (request.Model.Groups.Count > 0)
                {
                    foreach (string group in request.Model.Groups.First().Split(","))
                    {
                        newGroup.Add(new UserGroup()
                        {
                            GroupId = Convert.ToInt64(group),
                            UserId = request.Model.Id
                        });
                    }
                }
                

                Tools.UserGroupRepository.AddRange(newGroup);
                await Tools.UserGroupRepository.SaveChangesAsync();

                var result = Tools.Mapper.Map<UpdateUserDto>(user);

                return ResponseMessage<UpdateUserDto>.Success(result);
            }
        }
    }
}
