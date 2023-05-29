using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using ServisTakip.Core.Aspects.Autofac.Transaction;
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
                var userRepo = ServiceTool.ServiceProvider.GetService<IUserRepository>();
                var userGroupRepo = ServiceTool.ServiceProvider.GetService<IUserGroupRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var isThereAnyUser = await userRepo.GetAsync(u => u.Email == request.Model.Email);
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

                userRepo.Add(user);

                var result = mapper.Map<CreateUserDto>(user);

                await userRepo.SaveChangesAsync();

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

                userGroupRepo.AddRange(newGroup);
                await userGroupRepo.SaveChangesAsync();

                return ResponseMessage<CreateUserDto>.Success(result);
            }
        }
    }
}
