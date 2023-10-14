using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.UpdateUser.Contracts;

public interface IRepository
{
    Task<User?> GetUserById(Guid id, CancellationToken cancellationToken);
    Task<bool> SaveAsync(User user, CancellationToken cancellationToken);
}
