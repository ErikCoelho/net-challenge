using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.SearchUser.Contracts;

public interface IRepository
{
    Task<User?> GetUserById(Guid id, CancellationToken cancellationToken);
}
