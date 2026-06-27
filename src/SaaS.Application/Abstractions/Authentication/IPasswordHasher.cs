namespace SaaS.Application.Abstractions.Authentication;

public interface IPasswordHasher
{
    bool Verify(
        string password,
        string passwordHash);
}