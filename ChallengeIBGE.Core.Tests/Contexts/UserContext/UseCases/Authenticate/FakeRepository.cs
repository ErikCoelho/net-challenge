using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.Authenticate.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.UserContext.UseCases.Authenticate;

public class FakeRepository : IRepository
{
    private readonly User _user = new("André", "Baltieri", "contato@balta.io", "ABC123abc123");
    public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
    {
        if (email == _user.Email)
            return Task.FromResult<User?>(_user);

        return Task.FromResult<User?>(null);
    }
}
