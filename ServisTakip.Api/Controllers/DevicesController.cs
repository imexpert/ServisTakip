﻿using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Customers.Commands;
using ServisTakip.Business.Handlers.Customers.Queries;
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
        public async Task<IActionResult> GetDeviceWithQueryAsync(string filter)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceByFilterQuery() { Filter = filter }));
        }
    }
}
