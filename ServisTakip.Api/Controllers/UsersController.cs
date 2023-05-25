using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Authorizations.Commands;
using ServisTakip.Business.Handlers.Users.Commands;
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
            return CreateActionResult(await Mediator.Send(new AddUserCommand() { Model = createUserDto }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="updateUserDto"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<UpdateUserDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateUserDto updateUserDto)
        {
            return CreateActionResult(await Mediator.Send(new UpdateUserCommand() { Model = updateUserDto }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<UpdateUserDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync(long id)
        {
            return CreateActionResult(await Mediator.Send(new DeleteUserCommand() { Model = new DeleteUserDto() { Id = id } }));
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
