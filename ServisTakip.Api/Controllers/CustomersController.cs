using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Customers.Commands;
using ServisTakip.Business.Handlers.Customers.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Customers;

namespace ServisTakip.Api.Controllers
{
    public class CustomersController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerDto model)
        {
            return CreateActionResult(await Mediator.Send(new CreateCustomerCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync([FromBody] UpdateCustomerDto model)
        {
            return CreateActionResult(await Mediator.Send(new UpdateCustomerCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerAsync(long id)
        {
            return CreateActionResult(await Mediator.Send(new DeleteCustomerCommand() { Id = id }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<LastTradedCustomerInfoDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetLastTradedCustomerAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetSonIslemYapilanMusteriQuery()));
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
        public async Task<IActionResult> GetCustomerWithQueryAsync(string filter)
        {
            return CreateActionResult(await Mediator.Send(new GetCustomerByFilterQuery() { Filter = filter }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CustomerDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetCustomerByIdAsync(long customerId)
        {
            return CreateActionResult(await Mediator.Send(new GetCustomerByIdQuery() { CustomerId = customerId }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<LastTradedCustomerInfoDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetMainPageCustomerAsync(string rowId)
        {
            return CreateActionResult(await Mediator.Send(new GetMainPageCustomerQuery() { RowId = rowId }));
        }
    }
}
