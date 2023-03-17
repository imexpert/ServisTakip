using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Cities.Queries;
using ServisTakip.Business.Handlers.Reports.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Cities;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.Api.Controllers
{
    public class ReportsController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<CityDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> SozlesmeBasimRaporAsync([FromBody] SozlesmeBasimRaporFilter filter)
        {
            return CreateActionResult(await Mediator.Send(new SozlesmeBasimRaporQuery() { Model = filter }));
        }
    }
}
