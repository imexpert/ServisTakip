using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Devices.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Api.Controllers
{
    public class DevicesController : BaseApiController
    {
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
        public async Task<IActionResult> GetDeviceWithQueryAsync(long deviceId)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceByFilterQuery() { DeviceId = deviceId }));
        }

        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<SearchCustomerDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDevicesByAddressIdQueryAsync(long addressId)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceByAddressIdQuery() { AddressId = addressId }));
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
    }
}
