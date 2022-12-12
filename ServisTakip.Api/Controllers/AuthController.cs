using CarbonCalculator.Business.Handlers.Authorizations.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Authorizations.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Core.Utilities.Security.Jwt;
using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Api.Controllers
{
    public class AuthController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="loginUserDto"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<AccessToken>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            return CreateActionResult(await Mediator.Send(new LoginUserQuery() { LoginModel = loginUserDto }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateUserDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseMessage<CreateUserDto>))]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
        {
            return CreateActionResult(await Mediator.Send(new RegisterUserCommand() { Model = createUserDto }));
        }
    }
}
