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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateCustomerDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync([FromBody] CreateCustomerDto model)
        {
            return CreateActionResult(await Mediator.Send(new CreateCustomerCommand() { Model = model }));
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
            return CreateActionResult(await Mediator.Send(new GetLastTradedCustomerQuery()));
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
    }
}
