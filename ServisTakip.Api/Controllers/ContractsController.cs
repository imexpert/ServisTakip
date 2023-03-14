using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Contracts.Commands;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<ContractDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> CreateContractAsync([FromBody] CreateContractDto model)
        {
            return CreateActionResult(await Mediator.Send(new CreateContractCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<ContractDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> UpdateContractAsync([FromBody] UpdateContractDto model)
        {
            return CreateActionResult(await Mediator.Send(new UpdateContractCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<ContractDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> DeleteContractAsync(long id)
        {
            return CreateActionResult(await Mediator.Send(new DeleteContractCommand() { Id = id }));
        }
    }
}
