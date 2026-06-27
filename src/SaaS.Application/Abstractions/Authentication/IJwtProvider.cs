using SaaS.Domain.Entities;

namespace SaaS.Application.Abstractions.Authentication;

public interface IJwtProvider
{
    string Generate(User user);
}