using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Offers.Commands;
using ServisTakip.Business.Handlers.Offers.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Offers;

namespace ServisTakip.Api.Controllers
{
    public class OffersController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateOfferDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> CreateOfferAsync([FromBody] CreateOfferDto model)
        {
            return CreateActionResult(await Mediator.Send(new CreateOfferCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateOfferDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> UpdateOfferAsync([FromBody] CreateOfferDto model)
        {
            return CreateActionResult(await Mediator.Send(new UpdateOfferCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateOfferDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> SendOfferAsync([FromBody] CreateOfferDto model)
        {
            return CreateActionResult(await Mediator.Send(new SendOfferCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<bool>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> DeleteOfferAsync(long id)
        {
            return CreateActionResult(await Mediator.Send(new DeleteOfferCommand() { Id = id }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deviceServiceId"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<OfferDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetNoSendOfferAsync(long deviceServiceId)
        {
            return CreateActionResult(await Mediator.Send(new GetNoSendOfferQuery()
                { DeviceServiceId = deviceServiceId }));
        }
    }
}
