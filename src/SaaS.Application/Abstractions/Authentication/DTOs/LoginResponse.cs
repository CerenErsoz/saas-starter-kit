namespace SaaS.Application.Features.Authentication.DTOs;

public sealed class LoginResponse
{
    public string AccessToken { get; init; } = default!;
}