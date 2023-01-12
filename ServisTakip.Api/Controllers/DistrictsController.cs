using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Districts.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Districts;

namespace ServisTakip.Api.Controllers
{
    public class DistrictsController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cityId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DistrictDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDistrictListAsync(long cityId)
        {
            return CreateActionResult(await Mediator.Send(new GetDistrictListQuery() { CityId = cityId }));
        }
    }
}
