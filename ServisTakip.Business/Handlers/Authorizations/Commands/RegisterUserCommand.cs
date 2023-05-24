using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using ServisTakip.Business.Handlers.Authorizations.ValidationRules;
using ServisTakip.Core.Aspects.Autofac.Validation;
using ServisTakip.Core.Entities.Concrete;
using ServisTakip.Core.Extensions;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Core.Utilities.Security.Hashing;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Business.Handlers.Authorizations.Commands
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
                var isThereAnyUser = await _userRepository.GetAsync(u => u.Email == request.Model.Email);
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

                _userRepository.Add(user);

                var result = _mapper.Map<CreateUserDto>(user);

                await _userRepository.SaveChangesAsync();

                return ResponseMessage<CreateUserDto>.Success(result);
            }
        }
    }
}
