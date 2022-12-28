using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Sectors.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Sectors;

namespace ServisTakip.Api.Controllers
{
    public class SectorsController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<SectorDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetSectorListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetSectorListQuery()));
        }
    }
}
