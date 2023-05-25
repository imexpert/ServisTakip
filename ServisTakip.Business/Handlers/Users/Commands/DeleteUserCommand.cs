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
using Z.Expressions;

namespace ServisTakip.Business.Handlers.Users.Commands
{
    public class DeleteUserCommand : IRequest<ResponseMessage<DeleteUserDto>>
    {
        public DeleteUserDto Model { get; set; }
        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ResponseMessage<DeleteUserDto>>
        {
            public async Task<ResponseMessage<DeleteUserDto>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var userRepo = ServiceTool.ServiceProvider.GetService<IUserRepository>();
                var mapper = ServiceTool.ServiceProvider.GetService<IMapper>();

                var user = await userRepo.GetAsync(s => s.Id == request.Model.Id);
                userRepo.Delete(user);

                var result = mapper.Map<DeleteUserDto>(user);

                await userRepo.SaveChangesAsync();

                return ResponseMessage<DeleteUserDto>.Success(result);
            }
        }
    }
}
