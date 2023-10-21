using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
    Role? GetRoleByName(string role);
    Task SaveAsync(User user, CancellationToken cancellationToken);
    void SaveRole(Role userRole);
}
