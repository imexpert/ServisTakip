﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServisTakip.Business.Handlers.Authorizations.ValidationRules;
using ServisTakip.Core.Aspects.Autofac.Validation;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Core.Utilities.Security.Hashing;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.User;

namespace CarbonCalculator.Business.Handlers.Authorizations.Commands
{
    public class RegisterUserCommand : IRequest<ResponseMessage<CreateUserDto>>
    {
        public CreateUserDto Model { get; set; }
        public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseMessage<CreateUserDto>>
        {
            IUserRepository _userRepository;
            IMapper _mapper;

            public RegisterUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            {
                _userRepository = userRepository;
                _mapper = mapper;
            }

            [ValidationAspect(typeof(RegisterUserValidator), Priority = 1)]
            public async Task<ResponseMessage<CreateUserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
            {
                var isThereAnyUser = await _userRepository.GetAsync(u => u.Username == request.Model.Username);
                if (isThereAnyUser != null)
                    return ResponseMessage<CreateUserDto>.Fail(StatusCodes.Status400BadRequest, "Bu kullanıcı adı zaten eklenmiş.");

                HashingHelper.CreatePasswordHash(request.Model.Password, out var passwordSalt, out var passwordHash);

                var user = new User
                {
                    Username = request.Model.Username,
                    Firstname = request.Model.Firstname,
                    Lastname = request.Model.Lastname,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };

                _userRepository.Add(user);

                var result = _mapper.Map<CreateUserDto>(user);

                await _userRepository.SaveChangesAsync();

                return ResponseMessage<CreateUserDto>.Success(result);
            }
        }
    }
}