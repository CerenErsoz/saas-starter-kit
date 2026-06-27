using MediatR;
using SaaS.Application.Features.Authentication.DTOs;
using SaaS.SharedKernel.Common.Results;

namespace SaaS.Application.Features.Authentication.Commands.Login;

public sealed record LoginCommand(
    string Email,
    string Password
) : IRequest<Result<LoginResponse>>;