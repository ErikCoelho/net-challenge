using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.DeleteUser.Contracts;

public interface IRepository
{
    Task<User?> GetUserById(Guid id, CancellationToken cancellationToken);
    Task DeleteUser(User user, CancellationToken cancellationToken);
}
