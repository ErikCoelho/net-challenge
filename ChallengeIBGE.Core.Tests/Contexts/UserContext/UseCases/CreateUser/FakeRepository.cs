using ChallengeIBGE.Core.Contexts.UserContext.Entities;
using ChallengeIBGE.Core.Contexts.UserContext.UseCases.CreateUser.Contracts;

namespace ChallengeIBGE.Core.Tests.Contexts.UserContext.UseCases.CreateUser;

public class FakeRepository : IRepository
{
    private readonly User _user = new("André", "Baltieri", "contato@balta.io", "ABC123abc123");
    private readonly Role _role = new(Guid.NewGuid(), "User");
    public Task<bool> AnyAsync(string email, CancellationToken cancellationToken)
    {
        if (email == _user.Email)
            return Task.FromResult(true);

        return Task.FromResult(false);
    }

    public Role? GetRoleByName(string role)
    {
        if (role == _role.Name)
            return _role;

        return null;
    }

    public Task SaveAsync(User user, CancellationToken cancellationToken)
    {
        if (user == null)
            return Task.FromResult(false);

        return Task.FromResult(true);
    }

    public void SaveRole(Role userRole) { }
}
