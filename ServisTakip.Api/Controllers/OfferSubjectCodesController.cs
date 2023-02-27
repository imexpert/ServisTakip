using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.OfferSubjectCodes.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.OfferSubjectCodes;

namespace ServisTakip.Api.Controllers
{
    public class OfferSubjectCodesController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<OfferSubjectCodeDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetOfferSubjectCodeListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetOfferSubjectCodeQuery()));
        }
    }
}
