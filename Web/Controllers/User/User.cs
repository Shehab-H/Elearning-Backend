using Application.Services.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Web.Controllers.User
{
    [ApiController]
    [Route("api/[controller]")]
    public class User : Controller
    {
        private readonly IMediator _mediator;
        public User(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> UserRegister(RegisterUserCommand registerUserCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(registerUserCommand);

            if (result.Succeeded)
            {
                return Ok();
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("errors", error.Description);
                ModelState.AddModelError("status", "400");
                ModelState.AddModelError("title","user creation error");
            }
            return BadRequest(ModelState);
        }
    }
}
