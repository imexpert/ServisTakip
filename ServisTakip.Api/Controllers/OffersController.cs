using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.DeviceServices.Queries;
using ServisTakip.Business.Handlers.Offers.Commands;
using ServisTakip.Business.Handlers.Offers.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Offers;
using ServisTakip.Entities.DTOs.Reports;

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
        public async Task<IActionResult> SendOfferAsync([FromBody] OfferDto model)
        {
            return CreateActionResult(await Mediator.Send(new SendOfferCommand() { Model = model }));
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
        public async Task<IActionResult> SendOfferAgainAsync([FromBody] OfferDto model)
        {
            return CreateActionResult(await Mediator.Send(new SendOfferAgainCommand() { Model = model }));
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<OfferReport>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetOfferReportAsync(long deviceServiceId)
        {
            return CreateActionResult(await Mediator.Send(new DownloadOfferCommand() { DeviceServiceId = deviceServiceId }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<OfferReport>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetOrderReceiptReportAsync(long deviceServiceId)
        {
            return CreateActionResult(await Mediator.Send(new GetOrderReceiptReportQuery() { DeviceServiceId = deviceServiceId }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<OfferReport>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> SendOrderReceiptReportAsync([FromBody] MailModel model)
        {
            return CreateActionResult(await Mediator.Send(new SendOrderReceiptAsMailCommand() { Model= model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<OfferReport>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> SendOfferReportAsMailAsync(long deviceServiceId)
        {
            return CreateActionResult(await Mediator.Send(new SendOfferAsMailCommand() { DeviceServiceId = deviceServiceId }));
        }
    }
}
