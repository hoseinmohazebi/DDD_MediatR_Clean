using DDD.UserAccess.IntegrationEvents.Events;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DDD.API.Controllers.UserAccess
{
    [Route("api/[controller]/[action]")]
    [ApiController] 
    public class UserController : ControllerBase
    {
        private IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AddUserCommand cmd)
        {
            var res = await _mediator.Send(cmd);
            return Ok(res);
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginUserQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }

    }
}
