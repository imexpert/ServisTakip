using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.ResultCodes.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.ResultCodes;

namespace ServisTakip.Api.Controllers
{
    public class ResultCodesController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<ResultCodeDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetResultCodeListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetResultCodeListQuery()));
        }
    }
}
