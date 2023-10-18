using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.RemoveRoles.Contracts;

public interface IRepository
{
    Task<User?> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);
    Task RemoveRoleFromUserAsync(User? user, string role, CancellationToken cancellationToken);
    Task<Role?> GetRoleByNameAsync(string role, CancellationToken cancellationToken);
}
