using MediatR;
using SaaS.Application.Abstractions.Authentication;
using SaaS.Application.Features.Authentication.DTOs;
using SaaS.SharedKernel.Common.Results;

namespace SaaS.Application.Features.Authentication.Commands.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtProvider jwtProvider)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
            return Result<LoginResponse>.Failure("Invalid credentials.");

        var isValid = _passwordHasher.Verify(request.Password, user.PasswordHash);

        if (!isValid)
            return Result<LoginResponse>.Failure("Invalid credentials.");

        var token = _jwtProvider.Generate(user);

        return Result<LoginResponse>.Success(
            new LoginResponse
            {
                AccessToken = token
            });
    }
}