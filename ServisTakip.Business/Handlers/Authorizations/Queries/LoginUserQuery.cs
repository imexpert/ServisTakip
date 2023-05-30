using ServisTakip.Business.Handlers.Authorizations.ValidationRules;
using ServisTakip.Business.Handlers.UserGroups.Queries;
using ServisTakip.Core.Aspects.Autofac.Validation;
using ServisTakip.Core.CrossCuttingConcerns.Caching;
using ServisTakip.Core.Utilities.Security.Hashing;
using ServisTakip.Core.Utilities.Security.Jwt;
using ServisTakip.Entities.DTOs.User;
using StatusCodes = Microsoft.AspNetCore.Http.StatusCodes;

namespace ServisTakip.Business.Handlers.Authorizations.Queries
{
    public class LoginUserQuery : IRequest<ResponseMessage<UserDto>>
    {
        public LoginUserDto LoginModel { get; set; }

        public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, ResponseMessage<UserDto>>
        {
            private readonly ITokenHelper _tokenHelper;
            private readonly ICacheManager _cacheManager;

            public LoginUserQueryHandler(ITokenHelper tokenHelper, ICacheManager cacheManager)
            {
                _tokenHelper = tokenHelper;
                _cacheManager = cacheManager;
            }

            [ValidationAspect(typeof(LoginUserValidator), Priority = 1)]
            public async Task<ResponseMessage<UserDto>> Handle(LoginUserQuery request, CancellationToken cancellationToken)
            {
                var user = await Tools.UserRepository.GetAsync(u => u.Email == request.LoginModel.Email && u.Status);

                if (user == null)
                {
                    return ResponseMessage<UserDto>.Fail(StatusCodes.Status200OK, "Kullanıcı adı ya da şifre hatalı");
                }

                if (!HashingHelper.VerifyPasswordHash(request.LoginModel.Password, user.PasswordSalt, user.PasswordHash))
                {
                    return ResponseMessage<UserDto>.Fail(StatusCodes.Status200OK, "Kullanıcı adı ya da şifre hatalı");
                }

                var claims = Tools.UserRepository.GetClaims(user.Id);

                var accessToken = _tokenHelper.CreateToken<AccessToken>(user);
                accessToken.Claims = claims.Select(x => x.Name).ToList();

                user.RefreshToken = accessToken.RefreshToken;
                user.LastLogin = DateTime.Now;
                Tools.UserRepository.Update(user);
                await Tools.UserRepository.SaveChangesAsync();

                _cacheManager.Add($"{CacheKeys.UserIdForClaim}={user.Id}", claims.Select(x => x.Name), 3600);

                UserDto result = new UserDto()
                {
                    Email = user.Email,
                    Firstname = user.Firstname,
                    Lastname = user.Lastname,
                    Token = accessToken.Token,
                    Gender = user.Gender,
                    Avatar = user.Avatar ?? Array.Empty<byte>(),
                };

                var userGroupResponse = await Tools.Mediator.Send(new GetUserGroupsByUserIdQuery() { UserId = user.Id },
                    cancellationToken);

                if (userGroupResponse.IsSuccess)
                {
                    result.IsAdmin = userGroupResponse.Data.Any(s => s.Group.GroupName == "Admin");
                }

                return ResponseMessage<UserDto>.Success(result);
            }
        }
    }
}
