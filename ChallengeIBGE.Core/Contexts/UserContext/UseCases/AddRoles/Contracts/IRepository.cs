using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.AddRoles.Contracts;

public interface IRepository
{
    Task<Role?> GetRoleByNameAsync(string role, CancellationToken cancellationToken);
    Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task SaveAsync(User user, CancellationToken cancellationToken);
}
