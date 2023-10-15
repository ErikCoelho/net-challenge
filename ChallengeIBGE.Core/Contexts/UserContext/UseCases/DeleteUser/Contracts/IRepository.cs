using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.DeleteUser.Contracts;

public interface IRepository
{
    Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteUserAsync(User user, CancellationToken cancellationToken);
}
