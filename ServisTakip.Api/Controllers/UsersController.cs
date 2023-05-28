using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using ServisTakip.Business.Handlers.Authorizations.Commands;
using ServisTakip.Business.Handlers.Users.Commands;
using ServisTakip.Business.Handlers.Users.Queries;
using ServisTakip.Core.Utilities.Results;
using ServisTakip.Entities.DTOs.User;

namespace ServisTakip.Api.Controllers
{
    public class UsersController : BaseApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> AddUserAsync()
        {
            var form = await Request.ReadFormAsync();
            var file = form.Files.GetFile("file");

            var model = new CreateUserDto
            {
                Firstname = form["firstname"],
                Lastname = form["lastname"],
                Email = form["email"],
                Password = form["password"],
                Gender = byte.Parse(form["gender"]),
                Status = bool.Parse(form["status"])
            };

            byte[] fileBytes;
            using (var memoryStream = new MemoryStream())
            {
                await file.CopyToAsync(memoryStream);
                fileBytes = memoryStream.ToArray();
            }

            model.Avatar = fileBytes;

            return CreateActionResult(await Mediator.Send(new AddUserCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [EnableCors("AllowOrigin")]
        public async Task<IActionResult> UpdateUserAsync()
        {
            var form = await Request.ReadFormAsync();
            var file = form.Files.GetFile("file");

            var model = new UpdateUserDto
            {
                Id = long.Parse(form["id"]),
                Firstname = form["firstname"],
                Lastname = form["lastname"],
                Email = form["email"],
                Gender = byte.Parse(form["gender"]),
                Status = bool.Parse(form["status"]),
                Groups = form["groups"].ToList()
            };
            
            using (var memoryStream = new MemoryStream())
            {
                if (file is { Length: > 0 })
                {
                    await file.CopyToAsync(memoryStream);
                    model.Avatar = memoryStream.ToArray();
                }
            }

            return CreateActionResult(await Mediator.Send(new UpdateUserCommand() { Model = model }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<UpdateUserDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpDelete]
        public async Task<IActionResult> DeleteUserAsync(long id)
        {
            return CreateActionResult(await Mediator.Send(new DeleteUserCommand() { Model = new DeleteUserDto() { Id = id } }));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<UserDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetTechnicianUserListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetTechnicianUserListQuery()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<List<UserDto>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetUserListAsync()
        {
            return CreateActionResult(await Mediator.Send(new GetUserListQuery()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Consumes("application/json")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ResponseMessage<UserDto>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(string))]
        [HttpGet]
        public async Task<IActionResult> GetUserAsync(long id)
        {
            return CreateActionResult(await Mediator.Send(new GetUserQuery() { Id = id }));
        }
    }
}
