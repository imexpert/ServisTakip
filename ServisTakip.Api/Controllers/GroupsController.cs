using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Cities.Queries;
using ServisTakip.Business.Handlers.Groups.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Cities;
using ServisTakip.Entities.DTOs.Groups;

namespace ServisTakip.Api.Controllers
{
    public class GroupsController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<GroupDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetGroupListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetGroupListQuery()));
        }
    }
}
