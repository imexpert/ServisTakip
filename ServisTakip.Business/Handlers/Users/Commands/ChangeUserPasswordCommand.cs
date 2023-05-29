using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.IoC;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Core.Utilities.Security.Hashing;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Core.Aspects.Autofac.Transaction;
using Z.Expressions;

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
                var userRepo = ServiceTool.ServiceProvider.GetService<IUserRepository>();
                var userGroupRepo = ServiceTool.ServiceProvider.GetService<IUserGroupRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var user = await userRepo.GetAsync(s => s.Id == request.Model.Id);

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

                userRepo.Update(user);
                await userRepo.SaveChangesAsync();

                var result = mapper.Map<ChangeUserPasswordDto>(user);

                return ResponseMessage<ChangeUserPasswordDto>.Success(result);
            }
        }
    }
}
