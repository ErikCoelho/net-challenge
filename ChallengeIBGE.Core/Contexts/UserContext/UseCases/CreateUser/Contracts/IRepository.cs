using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser.Contracts;

public interface IRepository
{
    Task<bool> AnyAsync(string email, CancellationToken cancellationToken);
    Task SaveAsync(User user, CancellationToken cancellationToken);
}
