using ServisTakip.Core.Aspects.Autofac.Transaction;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Core.Utilities.Security.Hashing;
using ServisTakip.Entities.DTOs.User;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace ServisTakip.Business.Handlers.Users.Commands
{
    public class AddUserCommand : IRequest<ResponseMessage<CreateUserDto>>
    {
        public CreateUserDto Model { get; set; }
        public class AddUserCommandHandler : IRequestHandler<AddUserCommand, ResponseMessage<CreateUserDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<CreateUserDto>> Handle(AddUserCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyUser = await Tools.UserRepository.GetAsync(u => u.Email == request.Model.Email);
                if (isThereAnyUser != null)
                    return ResponseMessage<CreateUserDto>.Fail(StatusCodes.Status400BadRequest, "Bu kullanıcı adı zaten eklenmiş.");

                HashingHelper.CreatePasswordHash(request.Model.Password, out var passwordSalt, out var passwordHash);

                var user = new User
                {
                    CompanyId = Utils.CompanyId,
                    Avatar = request.Model.Avatar,
                    Firstname = request.Model.Firstname,
                    Lastname = request.Model.Lastname,
                    Gender = request.Model.Gender,
                    Email = request.Model.Email,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = request.Model.Status,
                };

                Tools.UserRepository.Add(user);

                var result = Tools.Mapper.Map<CreateUserDto>(user);

                await Tools.UserRepository.SaveChangesAsync();

                var userProcess = new UserProcess()
                {
                    UserId = user.Id
                };

                Tools.UserProcessRepository.Add(userProcess);
                await Tools.UserProcessRepository.SaveChangesAsync();

                List<UserGroup> newGroup = new List<UserGroup>();
                if (request.Model.Groups.Count > 0)
                {
                    foreach (string group in request.Model.Groups.First().Split(","))
                    {
                        newGroup.Add(new UserGroup()
                        {
                            GroupId = Convert.ToInt64(group),
                            UserId = user.Id
                        });
                    }
                }

                Tools.UserGroupRepository.AddRange(newGroup);
                await Tools.UserGroupRepository.SaveChangesAsync();

                return ResponseMessage<CreateUserDto>.Success(result);
            }
        }
    }
}
