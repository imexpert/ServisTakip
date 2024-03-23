using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Devices.Commands;
using ServisTakip.Business.Handlers.Devices.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Devices;

namespace ServisTakip.Api.Controllers
{
    public class DevicesController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<SearchCustomerDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceByIdAsync(long deviceId)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceByIdQuery() { DeviceId = deviceId }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<SearchCustomerDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceWithQueryAsync(long deviceId)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceByFilterQuery() { DeviceId = deviceId }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<SearchCustomerDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceByModelNameFilterAsync(string filter)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceByModelNameFilterQuery() { Filter = filter }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<SearchCustomerDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceBySerialNoFilterAsync(string filter)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceBySerialNoFilterQuery() { Filter = filter }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="addressId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceListByAddressIdAsync(long addressId)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceListByAddressIdQuery() { AddressId = addressId }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> AddDeviceAsync([FromBody] CreateDeviceDto model)
        {
            return CreateActionResult(await Mediator.Send(new CreateDeviceCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateDeviceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> UpdateDeviceAsync([FromBody] UpdateDeviceDto model)
        {
            return CreateActionResult(await Mediator.Send(new UpdateDeviceCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceTransferDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> UpdateDeviceTransferAsync([FromBody] DeviceTransferDto model)
        {
            return CreateActionResult(await Mediator.Send(new UpdateDeviceTransferCommand() { Model = model }));
        }
    }
}