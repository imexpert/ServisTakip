using ServisTakip.Core.Utilities.Security.Hashing;
using ServisTakip.Entities.DTOs.User;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace ServisTakip.Business.Handlers.Users.Commands
{
    public class ChangeUserPasswordCommand : IRequest<ResponseMessage<ChangeUserPasswordDto>>
    {
        public ChangeUserPasswordDto Model { get; set; }
        public class ChangeUserPasswordCommandHandler : IRequestHandler<ChangeUserPasswordCommand, ResponseMessage<ChangeUserPasswordDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<ChangeUserPasswordDto>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
            {
                var user = await Tools.UserRepository.GetAsync(s => s.Id == request.Model.Id);

                if (user == null)
                {
                    return ResponseMessage<ChangeUserPasswordDto>.Fail(StatusCodes.Status200OK, "Kullanıcı adı ya da şifre hatalı");
                }

                if (!HashingHelper.VerifyPasswordHash(request.Model.CurrentPassword, user.PasswordSalt, user.PasswordHash))
                {
                    return ResponseMessage<ChangeUserPasswordDto>.Fail(StatusCodes.Status200OK, "Kullanıcı adı ya da şifre hatalı");
                }

                if (request.Model.Password != request.Model.PasswordAgain)
                {
                    return ResponseMessage<ChangeUserPasswordDto>.Fail(StatusCodes.Status200OK, "Girmiş olduğunuz şifreler aynı değil.");
                }

                HashingHelper.CreatePasswordHash(request.Model.Password, out var passwordSalt, out var passwordHash);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

                Tools.UserRepository.Update(user);
                await Tools.UserRepository.SaveChangesAsync();

                var result = Tools.Mapper.Map<ChangeUserPasswordDto>(user);

                return ResponseMessage<ChangeUserPasswordDto>.Success(result);
            }
        }
    }
}
