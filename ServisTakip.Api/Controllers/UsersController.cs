using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Authorizations.Commands;
using ServisTakip.Business.Handlers.Users.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Api.Controllers
{
    public class UsersController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateUserDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] CreateUserDto createUserDto)
        {
            return CreateActionResult(await Mediator.Send(new RegisterUserCommand() { Model = createUserDto }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="createUserDto"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateUserDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] CreateUserDto createUserDto)
        {
            return CreateActionResult(await Mediator.Send(new RegisterUserCommand() { Model = createUserDto }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<UserDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetTechnicianUserListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetTechnicianUserListQuery()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<UserDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetUserListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetUserListQuery()));
        }
    }
}
