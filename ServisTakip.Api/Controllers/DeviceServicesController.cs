﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Authorizations.Queries;
using ServisTakip.Business.Handlers.Devices.Queries;
using ServisTakip.Business.Handlers.DeviceServices.Commands;
using ServisTakip.Business.Handlers.DeviceServices.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.DeviceServices;

namespace ServisTakip.Api.Controllers
{
    public class DeviceServicesController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateDeviceServiceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> AddDeviceServiceAsync([FromBody] CreateDeviceServiceDto model)
        {
            return CreateActionResult(await Mediator.Send(new CreateDeviceServicesCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceServiceDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetReceivedDeviceServicesListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetReceivedDeviceServicesListQuery()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceServiceDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetTechnicianAssignedDeviceServicesListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetTechnicianAssignedDeviceServicesListQuery()));
        }
    }
}
