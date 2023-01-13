using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.BootCodes.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.BootCodes;

namespace ServisTakip.Api.Controllers
{
    public class BootCodesController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<BootCodeDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetBootCodeListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetBootCodeListQuery()));
        }
    }
}
