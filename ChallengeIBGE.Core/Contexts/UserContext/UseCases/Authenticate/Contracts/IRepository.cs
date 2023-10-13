using ChallengeIBGE.Core.Contexts.UserContext.Entities;

namespace ChallengeIBGE.Core.Contexts.UserContext.UseCases.Authenticate.Contracts;

public interface IRepository
{
    Task<User?> GetUserByEmail(string email, CancellationToken cancellationToken);
}
