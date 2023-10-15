using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.Authenticate.Contracts;

public interface IRepository
{
    Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken);
}
