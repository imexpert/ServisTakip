using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Companies.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.Companies;

namespace ServisTakip.Api.Controllers
{
    public class CompaniesController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<CompanyDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetCompanyAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetCompanyQuery()));
        }
    }
}
