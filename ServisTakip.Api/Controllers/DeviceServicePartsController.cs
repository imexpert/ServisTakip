using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.DeviceServiceParts.Commands;
using ServisTakip.Business.Handlers.DeviceServiceParts.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.DeviceServiceParts;

namespace ServisTakip.Api.Controllers
{
    public class DeviceServicePartsController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateDeviceServicePartDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> CreateDeviceServicePartAsync([FromBody] CreateDeviceServicePartDto model)
        {
            return CreateActionResult(await Mediator.Send(new CreateDeviceServicePartCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateDeviceServicePartDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> UpdateDeviceServicePartAsync([FromBody] CreateDeviceServicePartDto model)
        {
            return CreateActionResult(await Mediator.Send(new UpdateDeviceServicePartCommand() { Model = model }));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateDeviceServicePartDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> DeleteDeviceServicePartAsync(long id)
        {
            return CreateActionResult(await Mediator.Send(new DeleteDeviceServicePartCommand() { Id = id }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceServicePartDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceServicePartListAsync(long deviceServiceId)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceServicePartListQuery() { DeviceServiceId = deviceServiceId }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceServicePartDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceServicePartAsync(long id)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceServicePartQuery() { Id = id }));
        }
    }
}
