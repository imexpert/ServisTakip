﻿using AutoMapper;
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
using Z.Expressions;

namespace ServisTakip.Business.Handlers.Users.Commands
{
    public class UpdateUserCommand : IRequest<ResponseMessage<UpdateUserDto>>
    {
        public UpdateUserDto Model { get; set; }
        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ResponseMessage<UpdateUserDto>>
        {
            public async Task<ResponseMessage<UpdateUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var userRepo = ServiceTool.ServiceProvider.GetService<IUserRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var isThereAnyUser = await userRepo.GetAsync(u => u.Email == request.Model.Email && u.Id != request.Model.Id);
                if (isThereAnyUser != null)
                    return ResponseMessage<UpdateUserDto>.Fail(StatusCodes.Status400BadRequest, "Bu kullanıcı adı zaten eklenmiş.");

                var user = await userRepo.GetAsync(s => s.Id == request.Model.Id);

                user.CompanyId = Utils.CompanyId;
                user.Avatar = request.Model.Avatar;
                user.Firstname = request.Model.Firstname;
                user.Lastname = request.Model.Lastname;
                user.Gender = request.Model.Gender;
                user.Email = request.Model.Email;
                user.Status = request.Model.Status;

                userRepo.Update(user);

                var result = mapper.Map<UpdateUserDto>(user);

                await userRepo.SaveChangesAsync();

                return ResponseMessage<UpdateUserDto>.Success(result);
            }
        }
    }
}