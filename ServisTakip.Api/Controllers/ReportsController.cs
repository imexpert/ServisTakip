using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Reports.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Contracts;
using ServisTakip.Entities.DTOs.Customers;
using ServisTakip.Entities.DTOs.Reports;

namespace ServisTakip.Api.Controllers
{
    public class ReportsController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<List<ContractDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> SozlesmeBasimRaporAsync([FromBody] SozlesmeBasimRaporFilter filter)
        {
            return CreatePagedActionResult(await Mediator.Send(new SozlesmeBasimRaporQuery() { Model = filter }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResult<List<CustomerReportDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpPost]
        public async Task<IActionResult> MusteriRaporAsync([FromBody] MusteriRaporFilter filter)
        {
            return CreatePagedActionResult(await Mediator.Send(new MusteriRaporQuery() { Model = filter }));
        }
    }
}
