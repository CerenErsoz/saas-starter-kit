using SaaS.Domain.Entities;

namespace SaaS.Application.Abstractions.Authentication;

public interface IUserRepository
{
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken);

    Task AddAsync(User user, CancellationToken cancellationToken);
}