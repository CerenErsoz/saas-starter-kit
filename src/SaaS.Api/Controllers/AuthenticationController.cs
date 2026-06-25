using MediatR;
using Microsoft.AspNetCore.Mvc;
using SaaS.Application.Features.Authentication.Commands.Login;
using SaaS.SharedKernel.Common.Results;

namespace SaaS.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var result = await _mediator.Send(command);

        return Ok(result);
    }
}