﻿using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.DeviceModels.Queries;
using ServisTakip.Core.Utilities.Results;
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
    }
}