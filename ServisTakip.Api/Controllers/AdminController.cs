using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using ServisTakip.Api.Hubs;
using ServisTakip.Business.Handlers.Sectors.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Sectors;
using StackExchange.Redis;

namespace ServisTakip.Api.Controllers
{
    public class AdminController : BaseApiController
    {
        private readonly IHubContext<ServisTakipHub> _hubContext;
        private readonly IDatabase _db;

        public AdminController(
            IHubContext<ServisTakipHub> hubContext,
            IConnectionMultiplexer multiplexer)
        {
            _hubContext = hubContext;
            _db = multiplexer.GetDatabase(5);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<SectorDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        [AllowAnonymous]
        public async Task RefreshPageAsync()
        {
            await _hubContext.Clients.All.SendAsync("RefreshPage");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<SectorDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        [AllowAnonymous]
        public async Task CloseSessionAsync()
        {
            await _hubContext.Clients.All.SendAsync("CloseSession");
        }
    }
}
