using ServisTakip.Business.Handlers.Authorizations.ValidationRules;
using ServisTakip.Core.Aspects.Autofac.Validation;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Core.Utilities.Security.Hashing;
using ServisTakip.Entities.DTOs.User;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace ServisTakip.Business.Handlers.Authorizations.Commands
{
    public class RegisterUserCommand : IRequest<ResponseMessage<CreateUserDto>>
    {
        public CreateUserDto Model { get; set; }
        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseMessage<CreateUserDto>>
        {

            [ValidationAspect(typeof(RegisterUserValidator), Priority = 1)]
            public async Task<ResponseMessage<CreateUserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyUser = await Tools.UserRepository.GetAsync(u => u.Email == request.Model.Email);
                if (isThereAnyUser != null)
                    return ResponseMessage<CreateUserDto>.Fail(StatusCodes.Status400BadRequest, "Bu kullanıcı adı zaten eklenmiş.");

                HashingHelper.CreatePasswordHash(request.Model.Password, out var passwordSalt, out var passwordHash);

                var user = new User
                {
                    CompanyId = Utils.CompanyId,
                    Email = request.Model.Email,
                    Firstname = request.Model.Firstname,
                    Lastname = request.Model.Lastname,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };

                Tools.UserRepository.Add(user);

                var result = Tools.Mapper.Map<CreateUserDto>(user);

                await Tools.UserRepository.SaveChangesAsync();

                return ResponseMessage<CreateUserDto>.Success(result);
            }
        }
    }
}
