using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.BootCodes.Queries;
using ServisTakip.Business.Handlers.DetectionCodes.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.DetectionCodes;

namespace ServisTakip.Api.Controllers
{
    public class DetectionCodesController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DetectionCodeDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDetectionCodeListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetDetectionCodeListQuery()));
        }
    }
}
