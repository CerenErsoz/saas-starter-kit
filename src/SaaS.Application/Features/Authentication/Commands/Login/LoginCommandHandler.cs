using MediatR;
using SaaS.SharedKernel.Common.Results;

namespace SaaS.Application.Features.Authentication.Commands.Login;

public sealed class LoginCommandHandler
    : IRequestHandler<LoginCommand, Result<string>>
{
    public async Task<Result<string>> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        if (request.Email != "test@test.com" || request.Password != "123456")
        {
            return Result<string>.Failure("Invalid credentials");
        }

        return Result<string>.Success("fake-jwt-token");
    }
}