using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Addresses.Commands;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Addresses;

namespace ServisTakip.Api.Controllers
{
    public class AddressesController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateAddressDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> CreateAddressAsync([FromBody] CreateAddressDto model)
        {
            return CreateActionResult(await Mediator.Send(new CreateAddressCommand() { Model = model }));
        }
    }
}
