using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.DeviceServices.Commands;
using ServisTakip.Business.Handlers.DeviceServices.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.DeviceServices;
using ServisTakip.Entities.DTOs.Offers;

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
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CreateBakimFormuDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> AddBakimFormuAsync([FromBody] CreateBakimFormuDto model)
        {
            return CreateActionResult(await Mediator.Send(new CreateBakimFormuCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceServiceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> AssignTechnicianDeviceServiceAsync([FromBody] DeviceServiceDto model)
        {
            return CreateActionResult(await Mediator.Send(new AssignTechnicianDeviceServicesCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceServiceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> GetAsync([FromBody] DeviceServiceDto model)
        {
            return CreateActionResult(await Mediator.Send(new AssignTechnicianDeviceServicesCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceServiceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> ReturnDeviceServiceToTechnicianAsync([FromBody] DeviceServiceDto model)
        {
            return CreateActionResult(await Mediator.Send(new ReturnDeviceServiceToTechnicianCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceServiceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> CloseDeviceServicesAsync([FromBody] DeviceServiceDto model)
        {
            return CreateActionResult(await Mediator.Send(new CloseDeviceServicesCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceServiceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> TakeDeviceServiceBackAsync([FromBody] DeviceServiceDto model)
        {
            return CreateActionResult(await Mediator.Send(new TakeDeviceServiceBackCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceServiceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> SendDeviceServiceToCloseAsync([FromBody] DeviceServiceDto model)
        {
            return CreateActionResult(await Mediator.Send(new SendDeviceServiceToCloseCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<OfferDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> ApproveDeviceServiceOfferAsync([FromBody] OfferDto model)
        {
            return CreateActionResult(await Mediator.Send(new ApproveDeviceServiceOfferCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceServiceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPut]
        public async Task<IActionResult> CancelDeviceServiceAsync([FromBody] DeviceServiceDto model)
        {
            return CreateActionResult(await Mediator.Send(new CancelDeviceServiceCommand() { Model = model }));
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
        public async Task<IActionResult> DeleteDeviceServiceAsync(long id)
        {
            return CreateActionResult(await Mediator.Send(new DeleteDeviceServiceCommand() { Id = id }));
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
        public async Task<IActionResult> GetToBeOfferedDeviceServicesListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetToBeOfferedDeviceServicesListQuery()));
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
        public async Task<IActionResult> GetSentOfferedDeviceServicesListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetSentOfferedDeviceServicesListQuery()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<DeviceServiceDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetDeviceServiceWithIdAsync(long id)
        {
            return CreateActionResult(await Mediator.Send(new GetDeviceServiceQuery() { DeviceServiceId = id }));
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
        public async Task<IActionResult> GetClosedDeviceServicesListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetClosedDeviceServicesListQuery()));
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
        public async Task<IActionResult> GetirKapatilmisServisListAsync(long deviceId)
        {
            return CreateActionResult(await Mediator.Send(new GetirKapatilmisServisListQuery(){DeviceId = deviceId }));
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<DeviceServiceDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetPartsExchangeDeviceServicesListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetPartsExchangeDeviceServicesListQuery()));
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
        public async Task<IActionResult> GetTechnicianDeviceServiceReportAsync(long userId)
        {
            return CreateActionResult(await Mediator.Send(new GetTechnicianDeviceServiceReportQuery() { UserId = userId }));
        }
    }
}
