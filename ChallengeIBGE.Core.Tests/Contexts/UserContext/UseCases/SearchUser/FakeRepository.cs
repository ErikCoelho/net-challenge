using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.SearchUser.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.UserContext.UseCases.SearchUser;

public class FakeRepository : IRepository
{
    private readonly User _user = new("André", "Baltieri", "contato@balta.io", "ABC123abc123");
    private readonly Guid customGuid = new("4c6a9c4a-ff72-499e-9e69-c6bfa0d23b2e");

    public Task<User?> GetUserById(Guid id, CancellationToken cancellationToken)
    {
        if (id == customGuid)
            return Task.FromResult<User?>(_user);

        return Task.FromResult<User?>(null);
    }
}
