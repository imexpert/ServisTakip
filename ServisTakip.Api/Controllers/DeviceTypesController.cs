using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.DeviceTypes.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.DeviceTypes;

namespace ServisTakip.Api.Controllers
{
    public class DeviceTypesController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceTypeDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceTypeListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceTypeListQuery()));
        }
    }
}
