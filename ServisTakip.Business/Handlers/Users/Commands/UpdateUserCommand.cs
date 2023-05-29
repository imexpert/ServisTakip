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
    public class UpdateUserCommand : IRequest<ResponseMessage<UpdateUserDto>>
    {
        public UpdateUserDto Model { get; set; }
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseMessage<UpdateUserDto>>
        {
            [TransactionScopeAspectAsync]
            public async Task<ResponseMessage<UpdateUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var userRepo = ServiceTool.ServiceProvider.GetService<IUserRepository>();
                var userGroupRepo = ServiceTool.ServiceProvider.GetService<IUserGroupRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var isThereAnyUser = await userRepo.GetAsync(u => u.Email == request.Model.Email && u.Id != request.Model.Id);
                if (isThereAnyUser != null)
                    return ResponseMessage<UpdateUserDto>.Fail(StatusCodes.Status400BadRequest, "Bu kullanıcı adı zaten eklenmiş.");

                var user = await userRepo.GetAsync(s => s.Id == request.Model.Id);

                user.CompanyId = Utils.CompanyId;
                if (request.Model.Avatar is { Length: > 0 })
                    user.Avatar = request.Model.Avatar;
                user.Firstname = request.Model.Firstname;
                user.Lastname = request.Model.Lastname;
                user.Gender = request.Model.Gender;
                user.Email = request.Model.Email;
                user.Status = request.Model.Status;

                userRepo.Update(user);
                await userRepo.SaveChangesAsync();

                var userGroups = await userGroupRepo.GetListAsync(s => s.UserId == request.Model.Id);
                userGroupRepo.DeleteRange(userGroups.ToList());
                await userGroupRepo.SaveChangesAsync();

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
                

                userGroupRepo.AddRange(newGroup);
                await userGroupRepo.SaveChangesAsync();

                var result = mapper.Map<UpdateUserDto>(user);

                return ResponseMessage<UpdateUserDto>.Success(result);
            }
        }
    }
}
