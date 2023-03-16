using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.DeviceModels.Queries;
using ServisTakip.Business.Handlers.Devices.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.DeviceModels;

namespace ServisTakip.Api.Controllers
{
    public class DeviceModelsController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceModelDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceModelListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceModelListQuery()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceBrandId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceModelDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceModelListWithBrandIdAsync(long deviceBrandId)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceModelListWithBrandIdQuery()
                { DeviceBrandId = deviceBrandId }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceModelDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetModelNameByFilterAsync(string filter)
        {
            return CreateActionResult(await Mediator.Send(new GetModelByNameFilterQuery() { Filter = filter }));
        }
    }
}
