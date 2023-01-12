using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Cities.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Cities;

namespace ServisTakip.Api.Controllers
{
    public class CitiesController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<CityDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetCityListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetCityListQuery()));
        }
    }
}
