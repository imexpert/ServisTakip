using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.DeviceBrands.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.DeviceBrands;

namespace ServisTakip.Api.Controllers
{
    public class DeviceBrandsController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceBrandDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceBrandListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceBrandListQuery()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceBrandDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceBrandListByTypeIdAsync(long deviceTypeId)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceBrandListWithTypeIdQuery()
                { DeviceTypeId = deviceTypeId }));
        }
    }
}
