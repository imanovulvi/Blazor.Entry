using Dictionary.Common.DTOs.Commands.User.ChangePassword;
using Dictionary.Common.DTOs.Commands.User.Create;
using Dictionary.Common.DTOs.Commands.User.Login;
using Dictionary.Common.DTOs.Commands.User.Update;
using Dictionary.Common.DTOs.Queries.User.Get;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dictionary.Api.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetUserDetail([FromQuery]GetUserDetailQueryRequest request)
        {
            return Ok(await mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginCommandRequest request)
        {
          return Ok(await  mediator.Send(request));
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommandRequest request) 
        {
            await mediator.Send(request);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UserUpdateCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserChangePasswordCommandRequest request)
        {
            await mediator.Send(request);
            return Ok();
        }
    }
}
