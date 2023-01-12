using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Querters.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Querters;

namespace ServisTakip.Api.Controllers
{
    public class QuertersController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="districtId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<QuerterDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetQuerterListAsync(long districtId)
        {
            return CreateActionResult(await Mediator.Send(new GetQuerterListQuery() { DistrictId = districtId }));
        }
    }
}
