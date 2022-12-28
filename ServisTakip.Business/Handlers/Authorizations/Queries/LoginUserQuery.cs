using MediatR;
using Microsoft.AspNetCore.Http;
using ServisTakip.Business.Handlers.Authorizations.ValidationRules;
using ServisTakip.Core.Aspects.Autofac.Validation;
using ServisTakip.Core.CrossCuttingConcerns.Caching;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Core.Utilities.Security.Hashing;
using ServisTakip.Core.Utilities.Security.Jwt;
using ServisTakip.DataAccess.Abstract;
using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Business.Handlers.Authorizations.Queries
{
    public class LoginUserQuery : IRequest<ResponseMessage<UserDto>>
    {
        public LoginUserDto LoginModel { get; set; }

        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, ResponseMessage<UserDto>>
        {
            private readonly IUserRepository _userRepository;
            private readonly ITokenHelper _tokenHelper;
            private readonly IMediator _mediator;
            private readonly ICacheManager _cacheManager;

            public LoginUserQueryHandler(IUserRepository userRepository, ITokenHelper tokenHelper, IMediator mediator, ICacheManager cacheManager)
            {
                _userRepository = userRepository;
                _tokenHelper = tokenHelper;
                _mediator = mediator;
                _cacheManager = cacheManager;
            }

            [ValidationAspect(typeof(LoginUserValidator), Priority = 1)]
            public async Task<ResponseMessage<UserDto>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(u => u.Email == request.LoginModel.Email && u.Status);

                if (user == null)
                {
                    return ResponseMessage<UserDto>.Fail(StatusCodes.Status200OK, "Kullanıcı adı ya da şifre hatalı");
                }

                if (!HashingHelper.VerifyPasswordHash(request.LoginModel.Password, user.PasswordSalt, user.PasswordHash))
                {
                    return ResponseMessage<UserDto>.Fail(StatusCodes.Status200OK, "Kullanıcı adı ya da şifre hatalı");
                }

                var claims = _userRepository.GetClaims(user.Id);

                var accessToken = _tokenHelper.CreateToken<AccessToken>(user);
                accessToken.Claims = claims.Select(x => x.Name).ToList();

                user.RefreshToken = accessToken.RefreshToken;
                _userRepository.Update(user);
                await _userRepository.SaveChangesAsync();

                _cacheManager.Add($"{CacheKeys.UserIdForClaim}={user.Id}", claims.Select(x => x.Name), 3600);

                UserDto result = new UserDto()
                {
                    Email = user.Email,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Token = accessToken.Token,
                };

                return ResponseMessage<UserDto>.Success(result);
            }
        }
    }
}
