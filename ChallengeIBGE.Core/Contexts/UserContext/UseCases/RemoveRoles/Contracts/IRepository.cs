using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.RemoveRoles.Contracts;

public interface IRepository
{
    Task RemoveRoleFromEmployeeAsync(Guid userId, string role, CancellationToken cancellationToken);
    Task SaveAsync(User user, CancellationToken cancellationToken);
}
