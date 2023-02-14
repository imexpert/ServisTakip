using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Cities.Queries;
using ServisTakip.Business.Handlers.Users.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Cities;
using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Api.Controllers
{
    public class UsersController : BaseApiController
    {
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
    }
}
