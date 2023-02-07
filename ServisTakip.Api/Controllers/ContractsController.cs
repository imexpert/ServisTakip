using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Contracts.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Contracts;

namespace ServisTakip.Api.Controllers
{
    public class ContractsController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<ContractDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetContractListAsync(long deviceId)
        {
            return CreateActionResult(await Mediator.Send(new GetContractListQuery() { DeviceId = deviceId }));
        }
    }
}
